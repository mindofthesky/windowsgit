import NeosProfileCard from "./NeosProfileCard";
import {
  LevFifBg,
  LevFifBgBox,
  LevFifBottomBox,
  LevFifIntroBlue,
  LevFifIntroBox,
  LevFifIntroNavy,
  LevFifLayout,
  LevFifProCon,
  LevFifTopBox,
  LevFifWrap,
} from "../../styles/joosikbox/neos";

const NeosLevFif = () => {
  return (
    <LevFifLayout>
      <LevFifWrap>
        <LevFifBgBox>
          <LevFifBg src="/assets/world.png" alt="world" />
        </LevFifBgBox>
        <LevFifTopBox>
          <LevFifIntroBox>
            <LevFifIntroBlue>미국 최초의 레버리지/인버스 ETF</LevFifIntroBlue>
            <LevFifIntroNavy>
              인 ProShares 개발 및 운용 미래에셋자산운용 사장, 글로벌ETF 헤드
              재직시
            </LevFifIntroNavy>
            <LevFifIntroBlue>글로벌 ETF 운용사</LevFifIntroBlue>
            <LevFifIntroNavy>로 성장하는데 주도적 역할</LevFifIntroNavy>
          </LevFifIntroBox>
          <LevFifProCon>
            <NeosProfileCard
              imageSrc="/assets/qt_bk.png"
              name="Name"
              profile="NEOS Investments LLC,
Co-founder"
            />
          </LevFifProCon>
        </LevFifTopBox>
        <LevFifBottomBox>
          <LevFifIntroBox>
            <LevFifIntroNavy>
              옵션 투자상품 개발 및 운용 전문가 QYLD(약 7조원 규모), NUSI(약
              1조원 규모)등
            </LevFifIntroNavy>
            <LevFifIntroBlue>미국에서 가장 큰 규모</LevFifIntroBlue>
            <LevFifIntroNavy>에 속하는</LevFifIntroNavy>
            <LevFifIntroBlue>옵션인컴 ETF</LevFifIntroBlue>
            <LevFifIntroNavy>들을 개발하고 운용</LevFifIntroNavy>
          </LevFifIntroBox>
          <LevFifProCon>
            <NeosProfileCard
              imageSrc="/assets/qt_bk.png"
              name="Name"
              profile="NEOS Investments LLC,
Co-founder"
            />
            <NeosProfileCard
              imageSrc="/assets/qt_bk.png"
              name="Name"
              profile="NEOS Investments LLC,
Co-founder"
            />
          </LevFifProCon>
        </LevFifBottomBox>
      </LevFifWrap>
    </LevFifLayout>
  );
};

export default NeosLevFif;
