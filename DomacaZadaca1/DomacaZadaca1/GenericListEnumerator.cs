using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomacaZadaca1 {
    public class GenericListEnumerator<X> : IEnumerator<X> {

        private IGenericList<X> _collection;
        private int _currentPosition = -1;

        public GenericListEnumerator(IGenericList<X> collection) {

            _collection = collection;
        }
        public bool MoveNext() {
            _currentPosition++;
         
            if (_currentPosition <= _collection.Count)
                return true;
            else
                return false;
        }
        public X Current {

            get {
                return _collection.GetElement(_currentPosition);
            }
        }
        object IEnumerator.Current {

            get {
                return Current;
            }

        }
        public void Dispose() {

            //ignore

        }
        public void Reset() {

            //ignore

        }

    }
}
