using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace A4
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;
        public event Action actions;

        public SingleFileWatcher(string fileName){
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += OnChanged;
        }
        public void Register(Action action){
            actions += action;
        }
        public void Unregister(Action action){
            if(actions != null)
                actions -= action;
        }
        public void OnChanged(object seder, FileSystemEventArgs arg){
            if (actions != null)
                actions();
        }
        public void Dispose()
        {
            if (Watcher != null)
                Watcher.Dispose();
        }
    }
}