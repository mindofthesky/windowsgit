import styled from "styled-components";
import { theme } from "../../themes/themes";

export const AboutNewsWrap = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  row-gap: 80px;
  width: 100%;
  padding-top: 80px;
  padding-bottom: 80px;
`;

export const HeadlineBox = styled.div`
  text-align: center;
`;

export const AboutNewsBox = styled.div`
  overflow: hidden;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  align-items: center;
  flex-direction: column;
  -moz-column-gap: 16px;
  column-gap: 16px;
  row-gap: 60px;
  width: 85%;
  max-width: 1440px;
  padding-top: 80px;
  padding-bottom: 80px;

  @media only screen and (max-width: 800px) {
    display: none;
    flex-direction: column;
    align-content: center;
    width: 85%;
    row-gap: 60px;
  }
`;

/** 반응형 mobile (슬라이더) */
export const AboutSliderLayout = styled.div`
  display: none;
  width: 100%;
  padding-bottom: 60px;
  margin-left: auto;
  margin-right: auto;

  @media only screen and (max-width: 800px) {
    display: block;
  }
`;

export const AboutSliderWrap = styled.div`
  position: relative;
  top: 80px;
  width: 360px;
  margin-right: auto;
`;

export const AboutIntroWrap = styled.div`
  width: 78%;
  padding-top: 60px;
  margin-left: auto;
  margin-right: auto;
`;

//box

export const SliderBox = styled.div`
  position: relative;
  display: block;
  box-sizing: border-box;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
  -webkit-touch-callout: none;
  -khtml-user-select: none;
  touch-action: pan-y;
  -webkit-tap-highlight-color: transparent;
`;

export const SliderItems = styled.div`
  position: absolute;
  left: 0;
  bottom: 0;
  max-width: 360px;
  width: 100vw;
`;

export const SliderIntroWrap = styled.div`
  width: 78%;
  padding-top: 60px;
  margin-left: auto;
  margin-right: auto;
`;

export const SliderNameBox = styled.div`
  display: flex;
  -moz-column-gap: 8px;
  column-gap: 8px;
  margin-bottom: 20px;

  @media only screen and (max-width: 800px) {
    align-items: flex-start;
    flex-direction: column;
    row-gap: 4px;
  }
`;

export const IntroName = styled.span`
  font-weight: 700;
  font-size: 24px;
  line-height: 28px;
  color: ${theme.colors.sub};
`;

export const IntroPosition = styled.span`
  font-weight: 700;
  font-size: 16px;
  line-height: 20px;
  color: ${theme.colors.disabled};
`;

export const IntroDesc = styled.span`
  white-space: pre-wrap;
  font-weight: 400;
  font-size: 14px;
  line-height: 28px;
  color: ${theme.colors.sub};
`;
