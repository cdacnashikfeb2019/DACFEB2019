double Power(float base, short index)
{
	if(index == 1)
		return base;
	return base * Power(base, index - 1);
}

