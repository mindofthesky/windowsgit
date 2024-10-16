import styled from "styled-components";
import { IFooterSectionProps } from "../../types/footerTypes";
import { theme } from "../../themes/themes";

export const FooterLayout = styled.div`
  height: 352px;
  font-size: 0.9375rem;
  color: #6d7783;
  border-style: solid;
  border-top-width: 2px;
  background-color: ${theme.colors.white};

  @media only screen and (max-width: 800px) {
    height: auto;
    width: 100%;
    max-width: 390px;
    padding-top: 40px;
    padding-bottom: 40px;
  }
`;

export const FooterWrap = styled.div`
  padding-top: 62px;
  padding-bottom: 62px;
  padding-left: 12.5%;
  padding-right: 12.5%;

  @media only screen and (max-width: 800px) {
    padding: 0;
    width: 88%;
    margin-left: auto;
    margin-right: auto;
  }
`;

export const FooterContainer = styled.div`
  display: flex;
  justify-content: space-between;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
  }
`;

/** footerLeft */

export const FooterLeftWrap = styled.div`
  display: flex;
  flex-direction: column;
`;

export const FooterRightWrap = styled.div`
  flex-direction: column;
  display: flex;
  padding-top: 33px;

  @media only screen and (max-width: 800px) {
    padding-top: 0;
  }
`;

export const FooterSection = styled.div<IFooterSectionProps>`
  display: flex;
  margin-bottom: ${(props) => props.customMarginBottom || "20px"};
`;

export const FooterSectionRight = styled(FooterSection)`
  margin-bottom: 40px;
`;

export const FooterEmailPopupTag = styled.button`
  color: ${theme.colors.disabled};
`;

export const FooterLogo = styled.img`
  flex-shrink: 0;
  width: 165px;
  height: 52px;

  @media only screen and (max-width: 800px) {
    width: 95px;
    height: 30px;
    margin: 24px 0 24px 0;
  }
`;

export const FooterDesc = styled.div`
  display: flex;
  align-items: flex-start;
  margin: auto 0;
  font-weight: 500;
  font-size: 16px;
  line-height: 19px;
  color: ${theme.colors.black};

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    font-weight: 500;
  }
`;

export const FooterDescBox = styled.div`
  display: flex;

  @media only screen and (max-width: 800px) {
    display: flex;
    justify-content: left;
    margin-bottom: 10px;
    font-size: 12px;
  }
`;

export const FooterRecruitTag = styled.a`
  display: flex;
  align-items: center;
`;

export const InfoBox = styled.div`
  font-weight: 700;
  color: ${theme.colors.sub};
`;

export const Partition = styled.div`
  width: 1px;
  height: 16px;
  margin-left: 12px;
  margin-right: 12px;
  background-color: ${theme.colors.disabled};
`;

export const Partitions = styled(Partition)`
  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const FooterInfo = styled.span`
  display: flex;
  gap: 20px;
  margin: auto 0;
  font-weight: 500;
  font-size: 16px;
  line-height: 28px;
  color: ${theme.colors.disabled};

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    gap: 8px;
    font-size: 12px;
    font-weight: 700;
    line-height: 28px;
  }
`;

export const FooterContact = styled.p`
  font-weight: 500;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.disabled};

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const MFooterContact = styled.p`
  display: none;
  font-weight: 500;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.disabled};

  @media only screen and (max-width: 800px) {
    display: block;
    font-size: 12px;
    line-height: 28px;
  }
`;

export const FooterIinkedin = styled.span`
  font-weight: 500;
  font-size: 16px;
  line-height: 20px;
  color: ${theme.colors.disabled};
`;

// 추후에 select로 변경예정 -> 현재 준비중입니다. alert로 수정
export const FooterSelect = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 200px;
  height: 40px;
  padding: 10px 20px;
  font-weight: 500;
  font-size: 16px;
  line-height: 19px;
  border: 1px solid ${theme.colors.enable};
  color: ${theme.colors.disabled};
  background-color: ${theme.colors.white};
  cursor: default;

  @media only screen and (max-width: 800px) {
    width: 55%;
    margin-top: 0;
    margin-bottom: 20px;
  }
`;

export const ArrowDownIcon = styled.img`
  width: 24px;
  height: 24px;
`;

export const IconContainer = styled.a`
  position: relative;
  flex-shrink: 0;
  width: 48px;
  height: 48px;

  @media only screen and (max-width: 800px) {
    width: 32px;
    height: 32px;
  }
`;

export const IconEllipse = styled.img`
  position: absolute;
  width: 100%;
  height: 100%;

  @media only screen and (max-width: 800px) {
    width: 32px;
    height: 32px;
  }
`;

export const Icon = styled.img`
  position: relative;
  z-index: 1;
  flex-shrink: 0;
  top: 50%;
  left: 50%;
  width: 46px;
  transform: translate(-50%, -50%);

  @media only screen and (max-width: 800px) {
    top: 55%;
    width: 32px;
    transform: translate(-50%, -55%);
  }
`;

export const IconRocket = styled.img`
  width: 46px;

  @media only screen and (max-width: 800px) {
    width: 32px;
  }
`;

export const FooterIconBox = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 28px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    justify-content: flex-start;
  }
`;
