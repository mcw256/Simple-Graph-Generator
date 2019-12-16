using SimpleGraphGenerator.ViewModels;
using SimpleGraphGenerator.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            GenerateGraphCommand = new RelayCommand(GenerateGraphCommandHandler);
            RerollVertexesLocationsCommand = new RelayCommand(RerollVertexesLocationsCommandHandler);
            SpaceVertexesEvenlyCommand = new RelayCommand(SpaceVertexesEvenlyCommandHandler);
            ColorShortestPathCommand = new RelayCommand(ColorShortestPathCommandHandler);
            VertexesNames = new ObservableCollection<string>();

            _myScene = myScene;
            EdgesAmount = 0;
            VertexesAmount = 15;
            Probability = 0.45;
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

        private bool _isGraphConnected;
        public bool IsGraphConnected
        {
            get => _isGraphConnected;
            set
            {
                if (value == _isGraphConnected) return;

                _isGraphConnected = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoaded;
        public bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                if (value == _isLoaded) return;

                _isLoaded = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _vertexesNames;
        public ObservableCollection<string> VertexesNames
        {
            get => _vertexesNames;
            set
            {
                _vertexesNames = value;
                OnPropertyChanged();
            }
        }

        private string _startingVertexName;
        public string StartingVertexName
        {
            get => _startingVertexName;
            set
            {
                if (value == _startingVertexName) return;

                _startingVertexName = value;
                OnPropertyChanged();
            }
        }

        private string _endingVertexName;
        public string EndingVertexName
        {
            get => _endingVertexName;
            set
            {
                if (value == _endingVertexName) return;

                _endingVertexName = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region commands
        public RelayCommand GenerateGraphCommand { get; private set; }
        public RelayCommand RerollVertexesLocationsCommand { get; private set; }
        public RelayCommand SpaceVertexesEvenlyCommand { get; private set; }
        public RelayCommand ColorShortestPathCommand { get; private set; }
        #endregion

        #region command handlers
        void GenerateGraphCommandHandler(object paramsArray)
        {
            VertexesNames.Clear(); //clear vertexes names list

            var values = (object[])paramsArray; //obtain parameters

            double probability = (double)values[0]; //values[0] its probability from gui
            int vertexesAmount = Convert.ToInt32(values[1]); //values [1] its vertexes amount from gui

            EdgesAmount = _myScene.DrawNewGraph((double)probability, (int)vertexesAmount);

            IsLoaded = true;
            IsGraphConnected = _myScene.IsGraphConnected();
            for (int i = 0; i < vertexesAmount; i++)
                VertexesNames.Add((i + 1).ToString());


        }

        void RerollVertexesLocationsCommandHandler(object obj)
        { 
            _myScene.RerollVertexesLocations();
        }

        void SpaceVertexesEvenlyCommandHandler(object obj)
        {
            _myScene.SpaceVertexesEvenly();
        }

        void ColorShortestPathCommandHandler(object paramsArray)
        {
            var values = (object[])paramsArray;

            if (values[0] == null || values[1] == null) return;

            if ((string)values[0] == "" || (string)values[1] == "") return;

            int beg = Convert.ToInt32(values[0]);
            int end = Convert.ToInt32(values[1]);

            _myScene.ColorShortestPath(beg, end);
        }

        #endregion


    }
}
