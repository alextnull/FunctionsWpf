﻿using FunctionsWpf.Infrastructure.Commands;
using FunctionsWpf.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FunctionsWpf.ViewModels
{
    /// <summary>
    /// Вью-модель главного окна приложения
    /// </summary>
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged при изменении свойста класса.
        /// </summary>
        /// <param name="property">Имя свойства.</param>
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Присваивает по ссылке переменной field значение value.
        /// </summary>
        /// <typeparam name="T">Тип параметров field и value.</typeparam>
        /// <param name="field">Ссылка на переменную.</param>
        /// <param name="value">Значение, которое необходимо присвоить field.</param>
        /// <param name="property">Имя свойства.</param>
        /// <returns>Возвращает false, если значение field равно value, иначе true.</returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(property);
            return true;
        }

        /// <summary>
        /// Присваивает переменной field значение value.
        /// </summary>
        /// <typeparam name="T">Тип параметров field и value.</typeparam>
        /// <param name="field"></param>
        /// <param name="value">Значение, которое необходимо присвоить field.</param>
        /// <param name="property">Имя свойства.</param>
        /// <returns>Возвращает false, если значение field равно value, иначе true.</returns>
        protected bool Set<T>(T field, T value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(property);
            return true;
        }

        /// <summary>
        /// Вызывает метод OnPropertyChanged для переданных свойств в properties.
        /// </summary>
        protected void OnPropertiesChanged(params string[] properties)
        {
            foreach (string property in properties)
            {
                OnPropertyChanged(property);
            }
        }

        #endregion

        #region Индекс выбранной функции

        private int _currentFunction = 0;

        /// <summary>
        /// Хранит индекс выбранной функции.
        /// </summary>
        public int CurrentFunction
        {
            get => _currentFunction;
            set
            {
                Set(ref _currentFunction, value);
                ChangeCValues();
                OnPropertiesChanged("A", "B", "C", "CValues", "Functions");
            }
        }

        #endregion

        #region Коэффициент 'a'

        /// <summary>
        /// Хранит коэффициенты 'a' для каждой функции.
        /// Элемент с индексом 0 представляет коэффициент 'a' линейной функции, 1 - квадратичной, ... , 4 -> 5-ой степени.
        /// </summary>
        private double[] _coefficientsA = new double[5];

        /// <summary>
        /// Хранит коэффициент 'a' для выбранной функции.
        /// </summary>
        public double A
        {
            get => _coefficientsA[CurrentFunction];
            set => Set(ref _coefficientsA[CurrentFunction], value);
        }

        #endregion

        #region Коэффициент 'b'

        /// <summary>
        /// Хранит коэффициенты 'b' для каждой функции.
        /// Элемент с индексом 0 представляет коэффициент 'b' линейной функции, 1 - квадратичной, ... , 4 -> 5-ой степени.
        /// </summary>
        private double[] _coefficientsB = new double[5];

        /// <summary>
        /// Хранит коэффициент 'b' для выбранной функции.
        /// </summary>
        public double B
        {
            get => _coefficientsB[CurrentFunction];
            set => Set(ref _coefficientsB[CurrentFunction], value);
        }

        #endregion

        #region Коллекция для хранения возможных значений коэффициента 'c'

        private ObservableCollection<int> _cValues;

        /// <summary>
        /// Хранит возможные значения коэффициента 'c' для выбранной функции.
        /// </summary>
        public ObservableCollection<int> CValues
        {
            get => _cValues;
            set => Set(ref _cValues, value);
        }

        #endregion

        #region Коэффициент 'c'

        /// <summary>
        /// Хранит коэффициенты 'c' для каждой функции.
        /// Элемент с индексом 0 представляет коэффициент 'c' линейной функции, 1 - квадратичной, ... , 4 -> 5-ой степени.
        /// </summary>
        private int[] _coefficientsC = { 1, 10, 100, 1000, 10000 };

        /// <summary>
        /// Хранит коэффициент 'c' для выбранной функции.
        /// </summary>
        public int C
        {
            get => _coefficientsC[CurrentFunction];
            set => Set(ref _coefficientsC[CurrentFunction], value);
        }

        #endregion

        #region Коллекция для хранения функций

        /// <summary>
        /// Хранит коллекции функций для каждой выбранной функции(в списке).
        /// </summary>
        private ObservableCollection<ObservableCollection<Function>> _functions;

        /// <summary>
        /// Хранит функции.
        /// </summary>
        public ObservableCollection<Function> Functions
        {
            get => _functions[CurrentFunction];
            set => Set(_functions[CurrentFunction], value);
        }
        #endregion

        #region Методы

        /// <summary>
        /// Изменяет коллекцию CValues в зависимости от выбранной функции.
        /// </summary>
        private void ChangeCValues()
        {
            CValues.Clear();
            for (var i = 0; i < 5; i++)
            {
                CValues.Add((i + 1) * (int)Math.Pow(10, CurrentFunction));
            }
        }

        #endregion

        #region Команды

        #region Add Row To Function Table Command

        /// <summary>
        /// Добавляет новую строку в таблицу с функциями.
        /// </summary>
        public ICommand AddRowToFunctionTableCommand { get; set; }

        /// <summary>
        /// Добавляет новую строку в таблицу с функциями при вызове команды AddRowToFunctionTableCommand.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        private void OnAddRowToFunctionTableCommandExecuted(object parameter)
        {
            var function = new Function();
            Functions.Add(function);
        }

        #endregion

        #endregion

        #region Методы инициализации 

        /// <summary>
        /// Инициализирует команды.
        /// </summary>
        private void InitializeCommands()
        {
            AddRowToFunctionTableCommand = new RelayCommand(OnAddRowToFunctionTableCommandExecuted);
        }

        /// <summary>
        /// Инициализирует коллекции.
        /// </summary>
        private void InitializeCollections()
        {
            CValues = new ObservableCollection<int>();
            ChangeCValues();

            _functions = new ObservableCollection<ObservableCollection<Function>>();
            for (var i = 0; i < 5; i++)
            {
                _functions.Add(new ObservableCollection<Function>());
            }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Инициализирует команды и коллекции.
        /// </summary>
        public MainWindowViewModel()
        {
            InitializeCollections();
            InitializeCommands();
        }

        #endregion
    }
}
