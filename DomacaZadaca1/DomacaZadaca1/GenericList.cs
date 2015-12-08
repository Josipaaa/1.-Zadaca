using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomacaZadaca1 {
    public class GenericList<X> : IGenericList<X> {

        private X[] _internalStorage;
        private int _lastPosition = -1;

        public GenericList() {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize) {
            _internalStorage = new X[initialSize];
        }

        public void Add(X item) {

            if (_lastPosition + 1 >= _internalStorage.Length) {

                X[] tempStorage = new X[_lastPosition + 1];

                for (int i = 0; i < _internalStorage.Length; i++) {
                    tempStorage[i] = _internalStorage[i];
                }
                _internalStorage = new X[2 * (_internalStorage.Length)];

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

        public bool Remove(X item) {

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

            X[] tempStorage = new X[_internalStorage.Length];
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
            _lastPosition--;
            return true;

        }

        public X GetElement(int index) {

            if ((index > _internalStorage.Length + 1) || (index < 0)) {
                throw new IndexOutOfRangeException();
            } else {
                for (int i = 0; i < _internalStorage.Length; i++) {
                    if (index.Equals(i)) {
                        return _internalStorage[i];
                    }
                }
                return default(X);
            }

        }

        public int IndexOf(X item) {

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
                _internalStorage[i] = default(X);
            }
            _lastPosition = -1;
        }

        public bool Contains(X item) {

            for (int i = 0; i < _internalStorage.Length; i++) {
                if (_internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator() {

            return new GenericListEnumerator<X>(this);

        }

        IEnumerator IEnumerable.GetEnumerator() {

            return GetEnumerator();
        }
    }
}

