using SimpleGraphGenerator.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            GenerateGraphCommand = new SimpleCommand(GenerateGraphCommandHandler);
            //link to some business model updater
        }

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
            //do stuff


        }

        #endregion


    }
}
