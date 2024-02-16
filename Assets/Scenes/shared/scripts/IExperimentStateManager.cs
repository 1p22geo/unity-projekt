namespace Lib
{

    public interface IExperimentStateManager
    {
        public void ResetExperiment();
        public void ExperimentStep(float dt);
        public ExperimentTimeState getTime();
    }
}