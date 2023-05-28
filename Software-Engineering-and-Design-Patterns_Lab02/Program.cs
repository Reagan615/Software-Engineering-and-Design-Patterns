public abstract class Client
{
	public abstract int GetReputation();
	public abstract void GetPriveleges();
}

public class User : Client
{
	private int _reputation;
	public override int GetReputation()
	{
		return _reputation;
	}
	public override void GetPriveleges()
	{
		_grantBasicAccess();
	}
	private void _grantBasicAccess()
	{
		Console.WriteLine("User now has basic access.");
	}

}
public abstract class Badges : Client
{
	protected Client _client;
	public abstract override int GetReputation();
	public abstract override void GetPriveleges();

}
public class CommunityBadge : Badges
{
	public CommunityBadge(Client decoratedClient)
	{
		_client = decoratedClient;
	}

	public override void GetPriveleges()
	{
		_grantGroupAccess();
		_client.GetPriveleges();
		
	}

	public override int GetReputation()
	{
		return _client.GetReputation() + 5;
	}
	private void _grantGroupAccess()
	{
		
	}
}

public class BannedBadge : Badges
{
	public BannedBadge(Client decoratedClient)
	{
		_client = decoratedClient;
	}

	public override void GetPriveleges()
	{
		_blockAccess();
		_client.GetPriveleges();
	}

	public override int GetReputation()
	{
		return _client.GetReputation() * 0;
	}
	private void _blockAccess()
	{

	}


}

public class HundredPostsBadge : Badges
{
	public HundredPostsBadge(Client decoratedClient)
	{
		_client = decoratedClient;
	}
	public override void GetPriveleges()
	{
		_client.GetPriveleges();
	}
	public override int GetReputation()
	{
		return _client.GetReputation() + 100;
	}
}