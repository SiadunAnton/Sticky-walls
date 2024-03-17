namespace Domain.Movement
{
	public interface IGravity
	{
		public void Stop();
		public void Restore();
		public void SetLevel(float power);
	}
}