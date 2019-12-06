using SimpleGraphGenerator.ViewModels;
using SimpleGraphGenerator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region contructor
        public MainWindowViewModel(Scene myScene)
        {
            GenerateGraphCommand = new RelayCommand(GenerateGraphCommandHandler) ;
            _myScene = myScene;
            EdgesAmount = 0;
            VertexesAmount = 15;
            Probability = 0.45;
            //link to some business model updater
        }
        #endregion

        #region fields
        Scene _myScene;
        #endregion

        #region properties
        private int _edgesAmount;
        public int EdgesAmount
        {
            get => _edgesAmount;
            set
            {
                if (value == _edgesAmount) return;

                _edgesAmount = value;
                OnPropertyChanged();
            }
        }

        private int _vertexesAmount;
        public int VertexesAmount
        {
            get => _vertexesAmount;
            set
            {
                if (value == _vertexesAmount) return;

                _vertexesAmount = value;
                OnPropertyChanged();
            }
        }

        private double _probability;
        public double Probability
        {
            get => _probability;
            set
            {
                if (value == _probability) return;

                _probability = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region commands
        public RelayCommand GenerateGraphCommand { get; private set; }
        #endregion

        #region command handlers
        void GenerateGraphCommandHandler(object paramsArray)
        {
            var values = (object[])paramsArray;

            double probability = (double)values[0];
            int vertexesAmount = Convert.ToInt32(values[1]);

            
            EdgesAmount = _myScene.DrawNewGraph((double)probability, (int)vertexesAmount);


        }

        #endregion


    }
}
