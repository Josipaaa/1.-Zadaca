using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomacaZadaca1 {

    public class IntegerList : IIntegerList {

        private int[] _internalStorage;
        private int _lastPosition = -1;

        public IntegerList() {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize) {
            _internalStorage = new int[initialSize];
        }

        public void Add(int item) {

            if (_lastPosition + 1 >= _internalStorage.Length) {

                int[] tempStorage = new int[_lastPosition + 1];

                for (int i = 0; i < _internalStorage.Length; i++) {
                    tempStorage[i] = _internalStorage[i];
                }
                _internalStorage = new int[2 * (_internalStorage.Length)];

                for (int i = 0; i < tempStorage.Length; i++) {
                    _internalStorage[i] = tempStorage[i];
                }
                _lastPosition++;
                _internalStorage[_lastPosition] = item;
            } else {
                _lastPosition++;
                _internalStorage[_lastPosition] = item;

            }

        }

        public bool Remove(int item) {

            for (int i = 0; i < _internalStorage.Length; i++) {
                if (_internalStorage[i].Equals(item)) {
                    if (RemoveAt(i) == true)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public bool RemoveAt(int index) {

            if ((index > _lastPosition + 1) || (index < 0))
                return false;

            int[] tempStorage = new int[_internalStorage.Length];
            int j = 0;

            for (int i = 0; i < _internalStorage.Length; i++) {
                if (!index.Equals(i)) {
                    tempStorage[j] = _internalStorage[i];
                    j++;
                }
            }
            for (int i = 0; i < _internalStorage.Length; i++) {
                _internalStorage[i] = tempStorage[i];
            }
            _lastPosition --;
            return true;
        }

        public int GetElement(int index) {

            if ((index > _internalStorage.Length + 1) || (index < 0)) {
                throw new IndexOutOfRangeException();
            } else {
                for (int i = 0; i < _internalStorage.Length; i++) {
                    if (index.Equals(i)) {
                        return _internalStorage[i];
                    }
                }
                return 0;
            }
        }

        public int IndexOf(int item) {

            for (int i = 0; i < _internalStorage.Length; i++) {
                if (_internalStorage[i].Equals(item)) {
                    return i;
                }
            }
            return -1;
        }

        public int Count {
            get {
                return _lastPosition + 1;
            }
        }

        public void Clear() {

            for (int i = 0; i < _internalStorage.Length; i++) {
                _internalStorage[i] = 0;
            }
            _lastPosition = -1;
        }

        public bool Contains(int item) {

            for (int i = 0; i < _internalStorage.Length; i++) {
                if (_internalStorage[i].Equals(item))
                    return true;

            }
            return false;
        }

    }
}
