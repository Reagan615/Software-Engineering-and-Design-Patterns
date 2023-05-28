API twoFactorRequiredAPI = new TwoFactorRequired()
{
	TwoFactorAuthentication = true,
	IsAdmin = true
};

API twoFactorNotRequiredAPI = new TwoFactorNotRequired()
{
	TwoFactorAuthentication = false,
	IsAdmin = false
};

User user1 = UserFactory.CreateUser(twoFactorRequiredAPI);
User user2 = UserFactory.CreateUser(twoFactorNotRequiredAPI);

Console.WriteLine(user1.GetType().Name);
Console.WriteLine(user2.GetType().Name);

public abstract class User
{
	public string Password { get; set; }
	public API Api { get; set; }
	public abstract void PasswordHash();
}
public class Administrator : User
{
	public override void PasswordHash() { }
}
public class AuthorizedUser : User
{
	public override void PasswordHash() { }
}

public interface API
{
	public bool TwoFactorAuthentication { get; set; }
	public bool IsAdmin { get; set; }
	public abstract User CreateUser();
	
}
public class TwoFactorRequired : API
{
	public bool TwoFactorAuthentication { get; set; }
	public bool IsAdmin { get; set; }
	public  User CreateUser()
	{
		bool twoFactorAuthentication = TwoFactorAuthentication;
		bool isAdmin = IsAdmin;

		if (twoFactorAuthentication)
		{
			if (isAdmin)
			{
				return new Administrator();
			}
			else
			{
				return new AuthorizedUser();
			}
		}
		else
		{
			throw new Exception("Two authorizations are required");
		}
	}
}


public class TwoFactorNotRequired : API
{
	public bool TwoFactorAuthentication { get; set; }
	public bool IsAdmin { get; set; }
	public User CreateUser()
	{
		bool isAdmin = IsAdmin;

		if (isAdmin)
		{
			return new Administrator();
		}
		else
		{
			return new AuthorizedUser();
		}
	}
}

public static class UserFactory
{
	public static User CreateUser(API api)
	{
		return api.CreateUser();
	}

}