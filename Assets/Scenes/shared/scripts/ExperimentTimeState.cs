namespace Lib
{

    public class ExperimentTimeState
    {
        public float time;
        public float maxTime;
        public float percentage;
        public bool over;
        public ExperimentTimeState(float _time, float _maxTime)
        {
            if(_time<0 || _maxTime<0){
                throw new System.ArgumentOutOfRangeException();
            }
            time = _time;
            maxTime = _maxTime;
            percentage = _time / _maxTime;
            over = time>maxTime;
        }
    }
}