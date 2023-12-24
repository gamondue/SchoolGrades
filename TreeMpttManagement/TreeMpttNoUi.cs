using gamon.TreeMptt;
using System;
using System.Collections.Generic;
using System.Text;

using gamon.TreeMptt;
using System.Threading;

namespace gamon.TreeMptt
{
    internal class TreeMpttNoUi
    {
        internal TreeMpttNoUi() 
        {

        }
        internal void SaveTreeMpttBackground()
        {
            Thread BackgroundSaveThread;
            //Commons.BackgroundSaveThread = new Thread(CommonsWpf.SaveTreeMptt.SaveTreeMpttBackground);
            BackgroundSaveThread = new Thread(SaveTreeBackgroundMptt());
            BackgroundSaveThread.Start();

            TreeMpttNoUi tree = new TreeMpttNoUi();

        }
        private ParameterizedThreadStart SaveTreeBackgroundMptt()
        {
            throw new NotImplementedException();
        }
    }
}
