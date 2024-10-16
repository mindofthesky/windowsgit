import styled from "styled-components";
import { theme } from "../../themes/themes";

export const MapContainer = styled.div`
  width: 100%;
  height: 100%;
  margin-bottom: 40px;

  @media only screen and (max-width: 800px) {
    height: 202px;
    border-radius: 8px;
  }
`;

export const ContentMapDesc = styled.div`
  display: flex;
  padding: 24px 0;
  border-bottom: 1px solid #e6e6e6;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    gap: 4px;
    padding: 0;
    border-bottom: 1px solid transparent;
  }
`;

export const ContentName = styled.div`
  width: 128px;

  @media only screen and (max-width: 800px) {
    width: 70px;
    font-size: 14px;
    font-style: normal;
    font-weight: 500;
    line-height: 19.6px;
    color: ${theme.colors.disabled};
  }
`;

export const ContentDesc = styled.div`
  @media only screen and (max-width: 800px) {
    float: left;
    margin-bottom: 4px;
    font-size: 14px;
    font-style: normal;
    font-weight: 500;
    line-height: 19.6px;
    color: ${theme.colors.sub};

    &:first-child {
      left: 120px;
    }
  }
`;

export const ContentCollaboBox = styled.div`
  align-items: center;
  width: 288px;
  min-height: 50px;
  background-color: #f7f7f7;

  @media only screen and (max-width: 800px) {
    width: 100px;
    min-height: 20px;
  }
`;

export const ContentCollaboName = styled.p`
  text-align: center;
  margin-top: 12px;
  font-weight: 700;

  @media only screen and (max-width: 800px) {
    margin-top: 0;
    padding: 4px;
    font-size: 14px;
    font-weight: 400;
  }
`;

export const ContentCollaboDescBox = styled.form`
  display: flex;
  flex-direction: column;
  justify-content: center;
  height: 397px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    width: 100%;
    margin-top: 90%;
  }
`;

export const ContactMapBox = styled.div`
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  align-items: center;
  row-gap: 60px;
  -moz-column-gap: 16px;
  column-gap: 16px;
  max-width: 1440px;
  width: 85%;
  padding-bottom: 80px;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    align-content: center;
    row-gap: 0px;
    width: 100%;
  }
`;

export const ContentMapDescBox = styled.div`
  height: 397px;
  width: 500px;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    align-content: center;
    justify-content: center;
    row-gap: 30px;
    width: 100%;
    height: auto;
  }
`;

export const ContentTitle = styled.div`
  padding-bottom: 40px;
  font-size: 24px;
  font-weight: bolder;
  color: ${theme.colors.black};

  @media only screen and (max-width: 800px) {
    padding-bottom: 20px;
    text-align: center;
    font-size: 16px;
    font-weight: 700;
    line-height: 26px;
    color: ${theme.colors.sub};
  }
`;

export const SubmitBtn = styled.button`
  display: flex;
  justify-content: center;
  align-items: center;
  flex: 1 0 0;
  width: 600px;
  padding: 20px 60px;
  text-align: center;
  font-size: 20px;
  font-style: normal;
  font-weight: 500;
  line-height: 28px;
  color: ${theme.colors.sub};
  border-radius: 8px;
  background: ${theme.colors.enable};
  transition: all 0.2s ease-out;

  &:hover {
    background: ${theme.colors.primary};
    transition: all 0.2s ease-out;
  }

  @media only screen and (max-width: 800px) {
    width: 327px;
    height: 36px;
    padding: 6px 12px;
    font-size: 12px;
    border-radius: 6px;
    background: ${theme.colors.primary};
  }
`;
