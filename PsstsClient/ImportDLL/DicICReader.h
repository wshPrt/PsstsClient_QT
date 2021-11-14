



extern "C" { 

	_declspec(dllexport) int DICOpenPort(int icport,int icbaud);	
	_declspec(dllexport) bool MKBOpenPort(int Port, int BaudRate);	
	_declspec(dllexport) bool ReadCard(int ct);
	_declspec(dllexport) long DICGetStatus();
	_declspec(dllexport) char * DICGetCardType();
	_declspec(dllexport) bool MKBClosePort();
	_declspec(dllexport) bool DICClose();
	_declspec(dllexport) char * AT24C02ReadFile();
	_declspec(dllexport) char * DICGetErrorMsg(int ErrorCode);
	_declspec(dllexport) char * GetCardData(int Index);
	_declspec(dllexport) int CheckCard();
	//_declspec(dllexport) bool WriteCard(long BuyPower, long BuyNums, LPCTSTR Customerid);	
	_declspec(dllexport) bool ZTWriteCard(char * f1);
	//×ÔÖúÖÕ¶ËÍþÊ¢
	_declspec(dllexport) bool CWSWriteCard(int psamsite,char * f1,char * f2,char * f3,char * f4,char * f5,char * f6,char * f7);	
	//·þÎñ¿Ø¼þÐ´¿¨ÍþÊ¢
	_declspec(dllexport) bool WSWriteCard(int psamsite,char * f1,char * f2,char * f3,char * f4,char * f5,char * f6,char * f7);	
};
HANDLE icdev;
unsigned char icWrite[1024],icRead[1024];
unsigned char icRead0[1024];
unsigned char st_icRead0[1024];
unsigned char icRead1[1024];
unsigned char icRead2[1024];
unsigned char icRead3[1024];
unsigned char icRead4[1024];
unsigned char icRead5[1024];
unsigned char icRead6[1024];
int st, lenth,wskey_len;
char c3[1024];
unsigned char c1[1024];
char UserReset8[60];
unsigned char UserReset[10];
int  UserReset8Length;
char CardType[50];
char CommandData0[2048];
char CommandData1[1024];
char CommandData2[1024];
char CommandData3[1024];
char CommandData4[1024];
char CommandData5[1024];
char CommandData6[1024];

char Sw1Sw2[8];
char log[64];
char crand[60];
char _rand[60];
char k1[64];
char k2[64];
char logTitle[1024];
char lastMsg[1024];
char creceive_data[1024];
bool psamSetOk;