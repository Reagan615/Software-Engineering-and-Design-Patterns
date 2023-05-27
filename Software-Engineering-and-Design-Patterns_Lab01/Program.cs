Hardware receiver = new Receivers();
Hardware amplifier = new Amplifiers();
Hardware radio = new Radios();


amplifier.SetRadio(1);
radio.SetLine(3);

receiver.ReceiveRadioMethod();

receiver.ReceiveRadio = new ReceiveAM();
receiver.ReceiveRadioMethod();

abstract class Hardware
{
	public ReceiveRadio ReceiveRadio { get; set; }
	public ReceiveLine ReceiveLine { get; set; }
	public void ReceiveRadioMethod()
	{
		ReceiveRadio.SwitchRadio();
	}
	public void ReceiveLineMethod()
	{
		ReceiveLine.SetLine();
	}
	public abstract void SetRadio(int strategy);
	public abstract void SetLine(int strategy);
	
}

class Receivers : Hardware
{
	public override void SetRadio(int strategy)
	{
		if (strategy == 1)
		{
			ReceiveRadio = new ReceiveAM();
			Console.WriteLine("Receive AM signal");
		} else if(strategy == 2)
		{
			ReceiveRadio = new ReceiveFM();
			Console.WriteLine("Receive FM signal");
		} else
		{
			ReceiveRadio = new ReceiveRadioNone();
			Console.WriteLine("Receive None");
		}
	}
	public override void SetLine(int strategy)
	{
		if(strategy == 1)
		{
			ReceiveLine = new ReceiveLineIn();
			Console.WriteLine("Set LineIn");
		} else if(strategy == 2)
		{
			ReceiveLine = new ReceiveMM();
			Console.WriteLine("Set MM");
		} else if(strategy == 3)
		{
			ReceiveLine = new ReceiveBluetooth();
			Console.WriteLine("Set Bluetooth");
		} else
		{
			ReceiveLine = new ReceiveLineNone();
			Console.WriteLine("Set LineNone");
		}
	}
	public Receivers()
	{
		ReceiveRadio = new ReceiveFM();
		ReceiveLine = new ReceiveMM();
	}

}

class Amplifiers : Hardware
{
	public override void SetRadio(int strategy)
	{
		ReceiveRadio = new ReceiveRadioNone();
		Console.WriteLine("Receive None");
	}
	public override void SetLine(int strategy)
	{
		if (strategy == 1)
		{
			ReceiveLine = new ReceiveLineIn();
			Console.WriteLine("Set LineIn");
		}
		else if (strategy == 2)
		{
			ReceiveLine = new ReceiveMM();
			Console.WriteLine("Set MM");
		}
		else if (strategy == 3)
		{
			ReceiveLine = new ReceiveBluetooth();
			Console.WriteLine("Set Bluetooth");
		}
		else
		{
			ReceiveLine = new ReceiveLineNone();
			Console.WriteLine("Set LineNone");
		}
	}
	
}
class Radios : Hardware
{
	public override void SetRadio(int strategy)
	{
		if (strategy == 1)
		{
			ReceiveRadio = new ReceiveAM();
			Console.WriteLine("Receive AM signal");
		}
		else if (strategy == 2)
		{
			ReceiveRadio = new ReceiveFM();
			Console.WriteLine("Receive FM signal");
		}
		else
		{
			ReceiveRadio = new ReceiveRadioNone();
			Console.WriteLine("Receive None");
		}
	}
	public override void SetLine(int strategy)
	{
		ReceiveLine = new ReceiveLineNone();
		Console.WriteLine("The method cannot be performed");
	}
	
}


interface ReceiveRadio
{

	public void SwitchRadio();
}

class ReceiveFM : ReceiveRadio
{
	public void SwitchRadio()
	{
		Console.WriteLine("Receive FM signal");
	}
}

class ReceiveAM : ReceiveRadio
{
	public void SwitchRadio()
	{
		Console.WriteLine("Receive AM signal");
	}
}

class ReceiveRadioNone : ReceiveRadio
{
	public void SwitchRadio()
	{
		Console.WriteLine("Receive none signal");
	}
}

interface ReceiveLine
{
	public void SetLine();
}

class ReceiveLineIn : ReceiveLine
{
	public void SetLine()
	{
		Console.WriteLine("Set Linein");
	}
}
class ReceiveMM : ReceiveLine
{
	public void SetLine()
	{
		Console.WriteLine("Set MM");
	}
}
class ReceiveBluetooth : ReceiveLine
{
	public void SetLine()
	{
		Console.WriteLine("Set Bluetooth");
	}
}
class ReceiveLineNone : ReceiveLine
{
	public void SetLine()
	{
		Console.WriteLine("Set LineNone");
	}
}

