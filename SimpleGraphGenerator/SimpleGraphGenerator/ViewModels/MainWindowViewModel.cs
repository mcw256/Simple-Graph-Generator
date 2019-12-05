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
            GenerateGraphCommand = new SimpleCommand(GenerateGraphCommandHandler);
            _myScene = myScene;
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

        private int _probability;
        public int Probability
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
        public SimpleCommand GenerateGraphCommand { get; private set; }
        #endregion

        #region command handlers
        void GenerateGraphCommandHandler()
        {
           // myScene


        }

        #endregion


    }
}
