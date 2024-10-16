import styled from "styled-components";
import { theme } from "../../themes/themes";

/** NeosLevOne */
export const NeosLevOneWrap = styled.div`
  padding-top: 80px;
  height: 940px;
  position: relative;

  @media only screen and (max-width: 800px) {
    padding-top: 0;
    height: 740px;
  }
`;

export const LevOneImgWrap = styled.div`
  z-index: -1;
  width: 100%;
  left: 0;
  bottom: 0;
  position: absolute;

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const LevOneBg = styled.img`
  object-fit: cover;
  width: 100%;
  height: 940px;
`;

export const LevOneDescWrap = styled.div`
  padding-top: 134px;
  padding-bottom: 108px;
  justify-content: space-between;
  flex-direction: column;
  max-width: 1440px;
  width: 75%;
  height: 100%;
  display: flex;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const LevOneTitle = styled.span`
  font-weight: 800;
  font-size: 40px;
  line-height: 64px;
  color: ${theme.colors.white};
  white-space: break-spaces;
`;

export const LevOneDescBox = styled.div`
  flex-direction: column;
  display: flex;
`;

export const LevOneName = styled.span`
  font-weight: 800;
  font-size: 24px;
  line-height: 36px;
  color: ${theme.colors.white};
  margin-bottom: 20px;
`;

export const LevOneDesc = styled.span`
  font-weight: 500;
  font-size: 15px;
  line-height: 28px;
  color: ${theme.colors.white};
  white-space: break-spaces;
`;

/** NeosLevTwo */

export const NeosLevTwoWrap = styled.div`
  height: 140px;
  position: relative;

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const LevTwoContentBox = styled.div`
  max-width: 1440px;
  width: 75%;
  height: 100%;
  display: flex;
  margin-left: auto;
  margin-right: auto;
`;

export const LevTwoContent = styled.div`
  text-align: center;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  width: 33.3%;
  display: flex;
  position: relative;
  white-space: break-spaces;
`;

export const CrossImg = styled.img`
  width: 40px;
  height: 40px;
  top: 50%;
  left: 100%;
  position: absolute;
`;

export const LevTwoName = styled.div`
  font-weight: 700;
  font-size: 20px;
  line-height: 24px;
  color: ${theme.colors.primary};
  margin-bottom: 12px;
`;

export const LevTwoDesc = styled.div`
  font-weight: 500;
  font-size: 20px;
  line-height: 28px;
  color: ${theme.colors.primary};
`;

// NeosLevTwo - mobile
export const MNeosTwoSwrap = styled.div`
  padding-bottom: 120px;
  padding-top: 80px;
  padding-bottom: 80px;
  align-items: center;
  flex-direction: column;
  position: relative;
  display: none;

  @media only screen and (max-width: 800px) {
    background-color: #fff;
    display: flex;
  }
`;

export const MCrossImgTop = styled.img`
  z-index: 1;
  width: 20px;
  height: 20px;
  top: 288px;
  position: absolute;
`;

export const MCrossImgDown = styled.img`
  z-index: 1;
  width: 20px;
  height: 20px;
  top: 484px;
  position: absolute;
`;

export const MBlueCircle = styled.div`
  background-color: ${theme.colors.primary};
  justify-content: center;
  align-items: center;
  flex-direction: column;
  display: flex;
  width: 240px;
  height: 240px;
  mix-blend-mode: multiply;
  border-radius: 50%;
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: -44px;
  position: relative;
`;

export const MTwoName = styled.div`
  font-weight: 700;
  font-size: 16px;
  line-height: 19px;
  color: #fff;
  margin-bottom: 20px;
`;

export const MTwoDesc = styled.div`
  font-weight: 500;
  font-size: 16px;
  line-height: 24px;
  color: #fff;
  text-align: center;
  white-space: break-spaces;
`;
/** NeosLevThr*/

export const NeosLevThrWrap = styled.div`
  padding-top: 160px;
  background-color: ${theme.colors.sectionBg};
  align-items: center;
  flex-direction: column;
  height: 980px;
  display: flex;
  position: relative;

  @media only screen and (max-width: 800px) {
    height: 400px;
    padding-top: 30px;
    background-color: #fff;
  }
`;

export const LevThrBg = styled.div`
  width: 100%;
  position: absolute;
  height: 780px;
  background-image: url("/assets/contect-neos-bg.png");
  background-position: top center;
  background-repeat: no-repeat;
  background-size: cover;

  @media only screen and (max-width: 800px) {
    height: 122px;
    margin-top: 96px;
    background-position: center;
  }
`;

export const LevThrBox = styled.div`
  flex-direction: column;
  max-width: 1440px;
  min-width: 276px;
  width: 88%;
  display: flex;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    padding-top: 0;
    background-color: #fff;
    height: auto;
    margin: 0;
  }
`;

export const LevThrContents = styled.div`
  row-gap: 80px;
  flex-direction: column;
  display: flex;
  margin-bottom: 90px;

  @media only screen and (max-width: 800px) {
    margin-bottom: 15px;
    row-gap: 20px;
    align-items: flex-start;
  }
`;

export const LevThrName = styled.div`
  -moz-column-gap: 20px;
  column-gap: 20px;
  align-items: center;
  display: flex;
  @media only screen and (max-width: 800px) {
    align-items: flex-start;
    flex-direction: column;
  }
`;

export const LevThrImg = styled.img`
  width: 202px;
  height: 58px;

  @media only screen and (max-width: 800px) {
    width: 98px;
    height: 28px;
  }
`;

export const LevThrDesc = styled.span`
  font-weight: 400;
  font-size: 60px;
  line-height: 76px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 400;
    font-size: 14px;
    line-height: 23px;
  }
`;

export const NeosArrowTag = styled.a`
  font-weight: 700;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.primary};
  justify-content: center;
  align-items: center;
  display: flex;

  @media only screen and (max-width: 800px) {
    font-weight: 700;
    font-size: 16px;
    line-height: 20px;
    width: 88%;
    margin-top: 30%;
    margin-left: 90px;
  }
`;

/** NeosLevFour */

export const NeosLevFourWrap = styled.div`
  text-align: center;
  padding-top: 160px;
  padding-bottom: 160px;
  align-items: center;
  flex-direction: column;
  display: flex;

  @media only screen and (max-width: 800px) {
    padding-top: 80px;
    padding-bottom: 80px;
  }
`;

export const LevFourTitleBox = styled.div`
  justify-content: center;
  min-width: 320px;
  display: flex;
  margin-bottom: 40px;
`;

export const LevFourTitle = styled.span`
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  display: flex;

  @media only screen and (max-width: 800px) {
    width: 88%;
    margin-bottom: 20px;
  }
`;

export const FourTitle = styled.span`
  font-weight: 800;
  font-size: 60px;
  line-height: 72px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 800;
    font-size: 30px;
    line-height: 36px;

    &:first-child {
      width: 100%;
    }
  }
`;

export const FourTitleImg = styled.img`
  width: 167px;
  height: 48px;
  margin-left: 20px;
  margin-right: 20px;

  @media only screen and (max-width: 800px) {
    width: 91px;
    height: 26px;
    margin-right: 9px;
    margin-left: 0;
  }
`;

export const LevFourDesc = styled.span`
  font-weight: 500;
  font-size: 24px;
  line-height: 40px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 100;
    font-size: 12px;
    line-height: 20px;
    white-space: pre-wrap;
  }
`;

/** NeosLevFif */

export const LevFifLayout = styled.div`
  padding-bottom: 160px;

  @media only screen and (max-width: 800px) {
    padding-top: 80px;
    padding-bottom: 80px;
  }
`;
export const LevFifWrap = styled.div`
  row-gap: 76px;
  flex-direction: column;
  max-width: 1440px;
  width: 88%;
  display: flex;
  margin-left: auto;
  margin-right: auto;
  position: relative;

  @media only screen and (max-width: 800px) {
    row-gap: 86px;
    width: 100%;
  }
`;

export const LevFifBgBox = styled.div`
  top: 0;
  left: 0;
  position: absolute;
`;

export const LevFifBg = styled.img`
  width: 1400px;
  height: 787px;
`;

export const LevFifTopBox = styled.div`
  column-gap: 73px;
  display: flex;

  @media only screen and (max-width: 800px) {
    align-items: center;
    flex-direction: column;
  }
`;

export const LevFifIntroBox = styled.span`
  width: 42%;
  white-space: break-spaces;

  @media only screen and (max-width: 800px) {
    min-width: 300px;
    margin-bottom: 40px;
  }
`;

export const LevFifIntroBlue = styled.span`
  font-weight: 700;
  font-size: 32px;
  line-height: 52px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 700;
    font-size: 16px;
    line-height: 28px;
  }
`;

export const LevFifIntroNavy = styled.span`
  font-weight: 500;
  font-size: 32px;
  line-height: 52px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 500;
    font-size: 16px;
    line-height: 28px;
  }
`;

export const LevFifBottomBox = styled.div`
  column-gap: 73px;
  display: flex;

  @media only screen and (max-width: 800px) {
    align-items: center;
    flex-direction: column;
  }
`;

/**  NeosProfileCard */
export const LevFifProCon = styled.div`
  column-gap: 94px;
  display: flex;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    min-width: 300px;
  }
`;

export const LevFifProBox = styled.div`
  flex-direction: column;
  display: flex;
`;

export const FifProName = styled.span`
  font-weight: 700;
  font-size: 32px;
  line-height: 28px;
  color: ${theme.colors.sub};
`;

export const FifProfile = styled.span`
  white-space: pre-wrap;
  font-weight: 500;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.sub};
  display: block;
  margin-bottom: 12px;
`;

/** NeosLevSix */

export const NeosLevSixWrap = styled.div`
  padding-top: 168px;
  padding-bottom: 244px;
  background-color: ${theme.colors.sectionBg};
  align-items: center;
  flex-direction: column;
  display: flex;

  @media only screen and (max-width: 800px) {
    padding-top: 90px;
    padding-bottom: 80px;
    padding-left: 5%;
    padding-right: 5%;
  }
`;

export const LevSixTitleBox = styled.div`
  -moz-column-gap: 20px;
  column-gap: 20px;
  justify-content: center;
  align-items: center;
  max-width: 1440px;
  width: 88%;
  display: flex;
  margin-bottom: 46px;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    -moz-column-gap: 8px;
    column-gap: 8px;
    margin-bottom: 20px;
  }
`;

export const SixTitleImg = styled.img`
  width: 167px;
  height: 48px;

  @media only screen and (max-width: 800px) {
    width: 90px;
    height: 26px;
  }
`;

export const SixTitle = styled.span`
  font-weight: 700;
  font-size: 52px;
  line-height: 62px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 700;
    font-size: 28px;
    line-height: 32px;
  }
`;

export const LevSixDescBox = styled.div`
  text-align: center;
  width: 68%;
  margin-bottom: 160px;

  @media only screen and (max-width: 800px) {
    width: 82%;
    margin-bottom: 80px;
  }
`;

export const LevSixDesc = styled.span`
  font-weight: 500;
  font-size: 24px;
  line-height: 40px;
  color: ${theme.colors.primary};

  @media only screen and (max-width: 800px) {
    font-weight: 500;
    font-size: 14px;
    line-height: 24px;
  }
`;

export const LevSixBoxes = styled.div`
  row-gap: 40px;
  -moz-column-gap: 40px;
  column-gap: 40px;
  justify-content: center;
  flex-wrap: wrap;
  max-width: 1440px;
  width: 88%;
  display: flex;

  @media only screen and (max-width: 800px) {
    width: 100%;
  }
`;

export const LevSixBox = styled.div`
  padding-right: 30px;
  padding-left: 40px;
  padding-top: 64px;
  padding-bottom: 64px;
  background-color: ${theme.colors.primary};
  row-gap: 20px;
  flex-direction: column;
  width: 48%;
  display: flex;

  @media only screen and (max-width: 800px) {
    padding: 20px;
    align-items: center;
    min-width: 320px;
  }
`;

export const SixBoxTitle = styled.span`
  font-weight: 700;
  font-size: 24px;
  line-height: 28px;
  color: ${theme.colors.white};

  @media only screen and (max-width: 800px) {
    font-weight: 700;
    font-size: 16px;
    line-height: 20px;
  }
`;

export const SixBoxDesc = styled.span`
  font-weight: 500;
  font-size: 20px;
  line-height: 32px;
  color: ${theme.colors.white};

  @media only screen and (max-width: 800px) {
    font-weight: 500;
    font-size: 14px;
    line-height: 20px;
  }
`;

/** Mobile */

export const MLevOneLayout = styled.div`
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%;
  position: relative;
  display: none;

  @media only screen and (max-width: 800px) {
    display: flex;
    flex-direction: column;
  }
`;

export const MNeosLogoImg = styled.img`
  width: 210px;
  height: 60px;
  margin-bottom: 40px;
`;

export const MLevOneBg = styled.img`
  width: 100%;
  height: 100%;
  left: 0;
  position: absolute;
  object-fit: cover;
  z-index: -1;
`;

export const MLevOneDesc = styled.span`
  font-weight: 500;
  font-size: 16px;
  line-height: 28px;
  color: #fff;
`;
