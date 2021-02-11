using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Newtonsoft.Json;

namespace UnitySystemicFramework {
    public abstract class Repository<T> : ScriptableObject where T : RepositoryContent<T> {
                
        List<T> items = new List<T>();

        List<T> cache = new List<T>();

        public bool allowRecycling;

        public bool allowDuplicates;

        public T Get(int index) { 
            return items[index];
        }  

        public T Get() {
            return items[items.Count - 1];
        }   

        public T Get (string contentName) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].contentName == contentName) {
                    return items[i];
                }
            }
            UnityEngine.Debug.Log("Unable to find repository content with name: " + contentName);
            return null;
        }

        public IEnumerable<T> GetAll() {
            return items;
        }

        public T GetFromCache() {
            UnityEngine.Debug.Log("Entity Repostiory getting entity from cache");
            int lastIndex = cache.Count - 1;
            T item = cache[lastIndex];
            cache.RemoveAt(lastIndex);
            return item;
        }

        public int Count () {
			return items.Count;
		}

        public int CacheCount() {
            return cache.Count;
        }

        public void Add(T item) {
            if (item.contentName == null ) {
                    UnityEngine.Debug.Log("Trying to add an item without a content name to a repository this will cause problems with retrieving the item, aborting");
                    return;
                }
            if (allowDuplicates) {
                items.Add(item);
                item.repositoryIndex = Count() - 1;
            } else {
                if (RepositoryContains(item.contentName)) {
                    return;
                }
                items.Add(item);
                item.repositoryIndex = Count() - 1;
            }
		}

        public bool RepositoryContains(string name) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].contentName == name) {
                    return true;
                }
            }
            return false;
        }

        public void Clear () {
            items.Clear();
            cache.Clear();
		}

		void Insert(int index, T item) {
			items.Insert(index, item);
		}

        public void RemoveAt(int index) {
            items[index].repositoryIndex = -1;
            T item = items[index];
            items.RemoveAt(index);
            RebuildIndexesFrom(index);
            if (allowRecycling) {
                cache.Add(item);
            }
        }

        void RebuildIndexesFrom(int index) {
            for (int i = index; i < items.Count; i++) {
                items[index].repositoryIndex = i;
            }
        }

        public virtual void Debug() {
            UnityEngine.Debug.Log("---- Debugging Repository ----");
            UnityEngine.Debug.Log("Contains " + items.Count + " items");
            for (int i = 0; i < items.Count; i++) {
                items[i].Debug();
            }

        }
    }
}