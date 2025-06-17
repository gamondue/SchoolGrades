using gamon.TreeMptt;
using SchoolGrades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SchoolGrades
{
    internal static partial class Commons
    {
        internal static TreeMptt NoUiTreeMptt;
        internal static void CreateAndStartBackgroundSavingThread()
        {
            // create a new tree that uses the controls in CallingForm
            NoUiTreeMptt = new TreeMptt(null, null, null, null, null,
                null, globalPicLed, null, null, null, null, null);
            // create and run the Thread that concurrently saves the Topics tree
            BackgroundSaveThread = new Thread(NoUiTreeMptt.SaveTreeMpttBackground);
            BackgroundSaveThread.Name = "BackgroundSaveThread";
            // start the Thread
            BackgroundSaveThread.Start();
            StartOperationsOnBackgroudSavingThread();
        }
        internal static void StartOperationsOnBackgroudSavingThread()
        {
            // lock the concurrent modification of synchronizing variables 
            if (!BackgroundTaskCanSave)
            {
                BackgroundTaskCanSave = true;
            }
        }
        internal static void StopOperationsOnBackgroundThread()
        {
            // disable the background saving task. When disabled, the concurrent
            // thread will receinve notification and stop modifying the database 

            // lock the concurrent modification of synchronizing variables 
            if (Commons.BackgroundTaskCanSave)
            {
                lock (LockBackgroundSavingVariables)
                {
                    BackgroundTaskCanSave = false;
                    // wait for the backgorund task to stop modifying the database
                    Thread.Sleep(2000);
                }
            }
        }
        internal static void TerminateBackgroundThread()
        {
            // command the background saving task to terminate
            // lock the concurrent modification of synchronizing variables 
            if (!BackgroundTaskClose)
            {
                lock (LockBackgroundSavingVariables)
                {
                    BackgroundTaskClose = true;
                }
            }
            if (BackgroundSaveThread != null
                && BackgroundSaveThread.ThreadState == System.Threading.ThreadState.Running)
            {
                // we wait for the saving Thread to finish
                // (it aborts its job in a point in which status is preserved)  
                BackgroundSaveThread.Join(3000);
            }
        }
        internal static bool MethodCanContinue()
        {
            return Commons.BackgroundTaskCanSave || !Commons.BackgroundThreadIsSaving;
        }
    }
}
