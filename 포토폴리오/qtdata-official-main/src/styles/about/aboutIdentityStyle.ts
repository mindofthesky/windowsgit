import styled from 'styled-components';
import { theme } from '../../themes/themes';

export const IdentityWrap = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  margin-top: 260px;
  padding-bottom: 80px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    width: 88%;
    margin-top: 60px;
    margin-left: auto;
    margin-right: auto;
    padding-bottom: 0px;
  }
`;

export const IdentityTitle = styled.div`
  margin-top: 80px;
  margin-bottom: 20px;
  text-align: center;
  font-size: 24px;
  font-style: normal;
  font-weight: 700;
  line-height: 24px;
  color: #444;

  @media only screen and (max-width: 800px) {
    margin-top: 20px;
    margin-bottom: 10px;
    font-size: 16px;
    line-height: 26px;
  }
`;

export const IdentityDesc = styled.p`
  text-align: center;
  font-size: 16px;
  font-style: normal;
  font-weight: 400;
  line-height: 28px;
  color: #444;

  @media only screen and (max-width: 800px) {
    margin-bottom: 40px;
    font-size: 12px;
    line-height: 26px;
  }
`;

export const IdentityBox = styled.div`
  overflow: hidden;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  margin-top: 80px;
  max-width: 1440px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    align-items: center;
    row-gap: 40px;
    margin-top: 40px;
  }
`;

export const IdentityItems = styled.div`
  display: flex;
  justify-content: center;
  flex-direction: column;
  width: 100%;
  margin-bottom: 10%;
`;

export const SignatureLogoRowBox = styled.div`
  display: flex;
  justify-content: center;
  margin: 36px auto;
  width: 90%;

  @media only screen and (max-width: 800px) {
    margin: 24px auto;
    width: 100%;
  }
`;

export const SignatureLogoRow = styled.div`
  display: flex;
  flex-shrink: 0;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 500px;
  max-width: 1076px;
  border-radius: 12px;
  border: 1px solid #d7d7d7;

  @media only screen and (max-width: 800px) {
    height: 137px;
  }
`;

export const SignatureLogo = styled.img`
  flex-shrink: 0;
  width: 565px;
  height: 177px;

  @media only screen and (max-width: 800px) {
    width: 162px;
    height: 51px;
  }
`;

export const SignatureLogoColBox = styled.div`
  display: flex;
  flex-direction: column;
  gap: 24px;
  width: 100%;
  max-width: 1076px;
  margin: 36px auto 16px;

  @media only screen and (max-width: 800px) {
    gap: 7px;
    margin: 0;
  }
`;

export const SignatureLogoBox = styled.div`
  display: flex;
  justify-content: space-between;
  gap: 24px;
  width: 100%;
  max-width: 1076px;
  margin: 36px auto 16px;

  @media only screen and (max-width: 800px) {
    gap: 7px;
    margin: 0;
  }
`;

export const SignatureLogoLeft = styled.div`
  display: flex;
  flex-shrink: 0;
  justify-content: center;
  align-items: center;
  width: 528px;
  height: 300px;
  border-radius: 12px;
  border: 1px solid #d7d7d7;

  @media only screen and (max-width: 800px) {
    flex-shrink: 0;
    width: 49%;
    height: 110px;
  }
`;

export const LogoTop = styled.img`
  display: flex;
  width: 330px;
  height: 103px;

  @media only screen and (max-width: 800px) {
    flex-shrink: 0;
    width: 113px;
    height: 35px;
  }
`;

export const FontSources = styled.span`
  font-size: 10px;
  font-style: normal;
  font-weight: 400;
  line-height: 18px;
  color: #444;
  max-width: 1076px;
`;

export const LogoDown = styled.img`
  flex-shrink: 0;
  width: 136px;
  height: 143px;

  @media only screen and (max-width: 800px) {
    flex-shrink: 0;
    width: 58px;
    height: 62px;
  }
`;

export const SignatureLogoRight = styled.div`
  display: flex;
  flex-shrink: 0;
  justify-content: center;
  align-items: center;
  width: 528px;
  height: 300px;
  border-radius: 12px;
  border: 1px solid #d7d7d7;
  background-color: #444;

  @media only screen and (max-width: 800px) {
    flex-shrink: 0;
    width: 49%;
    height: 110px;
  }
`;

export const IdentityDownBtnWrap = styled.button`
  display: inline-flex;
  align-items: center;
  padding: 18px 24px;
  margin-top: 40px;
  border-radius: 8px;
  background: ${theme.colors.primary};
  text-align: center;
  font-size: 20px;
  font-style: normal;
  font-weight: 500;
  line-height: 28px;
  color: ${theme.colors.sub};
  transition: all 0.2s ease-out;
  cursor: pointer;

  &:hover {
    background: ${theme.colors.enable};
    transition: all 0.2s ease-out;
  }

  @media only screen and (max-width: 800px) {
    height: 36px;
    margin-top: 0px;
    padding: 6px 12px;
    border-radius: 6px;
    background: ${theme.colors.primary};
    gap: 10px;
    font-size: 12px;
    line-height: 24px;
  }
`;
