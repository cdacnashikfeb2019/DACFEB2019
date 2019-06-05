#include "legacy\include\taxation.h"

namespace IjwBridge
{
	public ref class LegacyTaxPayer
	{
	public:
		LegacyTaxPayer(short age)
		{
			pWrapped = new Taxation::TaxPayer(age);
			Income = 0;
		}

		property double Income;

		double GetIncomeTax()
		{
			return pWrapped->IncomeTax(Income);
		}

		//Dispose 
		~LegacyTaxPayer()
		{
			delete pWrapped;
		}

		//Finalize
		!LegacyTaxPayer()
		{
			delete pWrapped;
		}
	private:
		Taxation::TaxPayer* pWrapped;
	};
}
