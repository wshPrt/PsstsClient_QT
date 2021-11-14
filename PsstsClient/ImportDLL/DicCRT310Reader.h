#pragma once

//读卡请求参数
typedef struct struReadCardData {
	char cardRandom[500];		//用户卡随机数
	char cardType[500];			//IC卡类型，ST表示水投，GW表示国网
	char cardSnr[500];			//卡序列号
	char mfFile82[500];			//[水投]基本文件
	char dfFile81[500];			//[水投]下行购电文件，[国网]用户信息文件
	char dfFile82[500];			//[水投]反写文件，[国网]钱包文件
	char dfFile83[1000];		//[水投]钱包文件，[国网]第一套费率文件
	char dfFile84[1000];		//[国网]第二套费率文件，水投留空
	char dfFile85[500];			//[水投]预留，[国网]返写文件
	char dfFile86[500];			//[水投]下行自定义回写文件
	char dfFile87[500];			//[水投]自定义信息反写文件
	char dfFile88[1000];		//[水投]下行参数设置文件
}struReadCardData, * lpstruReadCardData;

//写卡参数
typedef struct struWriteCardData {
	//文件
	char ammt[13];				//表号
	char cardType[500];			//IC卡类型，ST表示水投，GW表示国网
	char mfFile82[500];			//[水投]基本文件
	char dfFile81[500];			//[水投]下行购电文件，[国网]用户信息文件
	char dfFile82[500];			//[水投]反写文件，[国网]钱包文件
	char dfFile83[1000];		//[水投]钱包文件，[国网]第一套费率文件
	char dfFile84[1000];		//[国网]第二套费率文件，水投留空
	char dfFile85[500];			//*[水投]预留，[国网]返写文件
	char dfFile86[500];			//[水投]下行自定义文件
	char dfFile88[1000];		//[水投]下行参数设置文件
	//认证参数及mac
	char tRandom[500];			//16个字符随机数
	char k1[500];				//密文，系统认证
	char k2[500];				//密文，外部认证
	char k3[500];				//[国网]外部认证
	char k4[500];				//[国网]外部认证
	char mfFile82Mac[500];		//[水投]基本文件mac
	char dfFile81Mac[500];		//[水投]下行购电文件Mac，[国网]用户参数信息文件mac
	char dfFile82Mac[500];		//[水投]反写文件mac，[国网]钱包文件mac
	char dfFile83Mac[500];		//[水投]钱包文件mac，[国网]第一套费率文件mac
	char dfFile84Mac[500];		//[国网]第二套费率文件mac
	char dfFile85Mac[500];		//*[国网]返写文件mac
	char dfFile86Mac[500];		//[水投]下行自定义反写文件mac
	char dfFile88Mac[500];		//[水投]下行参数设置文件mac
}struWriteCardData, * lpstruWriteCardData;

extern "C" {
	//提供的接口
	_declspec(dllimport) BOOL __stdcall DICOpenPort(int port);//打开串口
	_declspec(dllimport) BOOL __stdcall DICClose();//关闭串口
	_declspec(dllimport) long __stdcall DICGetStatus();
	_declspec(dllimport) char* __stdcall DICGetErrorMsg(long ErrorCode);
	_declspec(dllimport) char* __stdcall GetCardData(short Indim);
	_declspec(dllimport) BOOL __stdcall DICReadCard(lpstruReadCardData rcData);//读卡
	_declspec(dllimport) BOOL __stdcall DICWriteCard(lpstruWriteCardData wcData);//写卡
	_declspec(dllimport) long __stdcall DICResetDev();//复位
	_declspec(dllimport) BOOL __stdcall Entry();//允许插卡
	_declspec(dllimport) BOOL __stdcall DisEntry();//禁止插卡
	_declspec(dllimport) BOOL __stdcall MovePosition();//走卡
	_declspec(dllimport) BOOL __stdcall Eject();//吐卡
};
