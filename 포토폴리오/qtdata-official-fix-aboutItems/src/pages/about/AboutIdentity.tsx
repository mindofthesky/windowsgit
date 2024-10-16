import axios from 'axios';
import { signatureImages, signatureItems } from '../../datas/aboutItems';
import Head from '../../components/commons/Headline/Head';
import {
  FontSources,
  IdentityBox,
  IdentityDesc,
  IdentityDownBtnWrap,
  IdentityItems,
  IdentityTitle,
  IdentityWrap,
  LogoDown,
  LogoTop,
  SignatureLogo,
  SignatureLogoBox,
  SignatureLogoColBox,
  SignatureLogoLeft,
  SignatureLogoRight,
  SignatureLogoRow,
  SignatureLogoRowBox,
} from '../../styles/about/aboutIdentityStyle';
import { theme } from '../../themes/themes';

const AboutIdentity = () => {
  const handleZipDownload = async () => {
    try {
      const response = await axios.get(
        'https://sendemail.qtdata.co.kr/api/downloadZip',
        {
          responseType: 'blob',
          headers: {
            'Content-Type': 'application/zip',
            'Content-Disposition': 'attachment; filename=qtdataCI.zip',
          },
        }
      );

      const blob = new Blob([response.data], { type: 'application/zip' });

      const url = window.URL.createObjectURL(blob);
      const anchor = document.createElement('a');
      anchor.href = url;
      anchor.download = 'qtdataCI.zip';
      document.body.appendChild(anchor);
      anchor.click();
      document.body.removeChild(anchor);

      window.URL.revokeObjectURL(url);
    } catch (error) {
      console.error('오류메세지:', (error as Error).message);
    }
  };

  return (
    <IdentityWrap>
      <Head content='Identity' color={theme.colors.sub} />
      <IdentityTitle>Signature Logo</IdentityTitle>
      <IdentityDesc
        dangerouslySetInnerHTML={{ __html: signatureItems[0].desc }}
      />

      <IdentityDownBtnWrap onClick={handleZipDownload}>
        Download Logo
      </IdentityDownBtnWrap>

      <IdentityBox>
        <IdentityItems>
          <SignatureLogoRowBox>
            <SignatureLogoRow>
              <SignatureLogo
                src={signatureImages[0].src}
                alt={signatureImages[0].alt}
              />
            </SignatureLogoRow>
          </SignatureLogoRowBox>
          <SignatureLogoColBox>
            <SignatureLogoBox>
              <SignatureLogoLeft>
                <LogoTop
                  src={signatureImages[1].src}
                  alt={signatureImages[1].alt}
                />
              </SignatureLogoLeft>
              <SignatureLogoRight>
                <LogoTop
                  src={signatureImages[2].src}
                  alt={signatureImages[2].alt}
                />
              </SignatureLogoRight>
            </SignatureLogoBox>
            <FontSources>
              *퀀텀데이터의 폰트타입은 레페리와 윤디자인이 만든 '레페리 포인트
              타입' 서체를 라이센스 규정을 준수하여 사용합니다.
            </FontSources>
          </SignatureLogoColBox>
        </IdentityItems>

        <IdentityItems>
          <IdentityTitle>Symbol Logo</IdentityTitle>
          <IdentityDesc
            dangerouslySetInnerHTML={{ __html: signatureItems[1].desc }}
          />
          <SignatureLogoBox>
            <SignatureLogoLeft>
              <LogoDown
                src={signatureImages[3].src}
                alt={signatureImages[3].alt}
              />
            </SignatureLogoLeft>
            <SignatureLogoRight>
              <LogoDown
                src={signatureImages[4].src}
                alt={signatureImages[4].alt}
              />
            </SignatureLogoRight>
          </SignatureLogoBox>
        </IdentityItems>
      </IdentityBox>
    </IdentityWrap>
  );
};

export default AboutIdentity;
