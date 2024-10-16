import styled from "styled-components";
import { theme } from "../../themes/themes";

export const ContactAgreeWrap = styled.div`
  width: 100%;
  max-width: 800px;
  margin-bottom: 24px;
  margin-top: 20px;
`;

export const AgreeCheckBox = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  margin-bottom: 24px;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    gap: 10px;
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

export const ContactInquiryBox = styled.div`
  margin-top: 40px;
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

export const ContactItems = styled.div`
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;

  @media only screen and (max-width: 800px) {
    width: 100%;
  }
`;

export const ContactBox = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
  max-width: 800px;
  text-align: center;

  @media only screen and (max-width: 800px) {
    width: 100%;
  }
`;

export const ContactLabel = styled.div`
  display: flex;
  justify-content: flex-start;
  margin-top: 20px;
  margin-bottom: 10px;
  font-size: 20px;
  font-weight: 500;
  line-height: 28px;

  @media only screen and (max-width: 800px) {
    font-size: 12px;
    font-weight: 500;
    line-height: 20px;
    color: ${theme.colors.sub};
  }
`;

interface ContactProps {
  error?: boolean;
}

export const ContactInput = styled.input<ContactProps>`
  align-items: center;
  width: 600px;
  padding: 18px;
  border: 1px solid #d7d7d7;
  border-radius: 8px;
  font-size: 20px;
  ${({ error }) => error && `border-color: #F04452;`}

  @media only screen and (max-width: 800px) {
    width: 327px;
    padding: 8px 12px;
  }
`;

export const ContactTextArea = styled.textarea<ContactProps>`
  width: 600px;
  min-height: 300px;
  border: 1px solid #d7d7d7;
  border-radius: 8px;
  ${({ error }) => error && `border-color: #F04452;`}

  @media only screen and (max-width: 800px) {
    width: 327px;
    min-height: 220px;
    padding: 8px 12px;
  }
`;

export const ContactCheckBox = styled.input<ContactProps>`
  margin-right: 8px;
  ${({ error }) => error && `border-color: #F04452;`}
`;

export const ContactErrMsg = styled.div<ContactProps>`
  ${({ error }) => error && `color: #F04452;`}
`;

export const TextAreaInfo = styled.p`
  margin-top: 10px;
  text-align: left;
  font-size: 20px;
  font-style: normal;
  line-height: 28px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-weight: 500;
    line-height: 20px;
    font-size: 12px;
    font-style: normal;
  }
`;

export const ErrorMsg = styled.div`
  text-align: left;
  color: red;

  @media only screen and (max-width: 800px) {
    font-size: 12px;
  }
`;

export const AgreeLabel = styled.label`
  font-size: 20px;
  font-style: normal;
  font-weight: 500;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-weight: 500;
    font-size: 12px;
    font-style: normal;
  }
`;

export const AgreeLabelBox = styled.div`
  display: flex;
  align-items: center;
  accent-color: ${theme.colors.primary};
`;

export const AgreePopupTag = styled.button`
  text-decoration: underline;
`;

export const ContactModalLayout = styled.div`
  z-index: 9999;
  display: inline-flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: flex-end;
  gap: 20px;
`;

export const ContactModalTitle = styled.p`
  text-align: left;
  font-size: 24px;
  font-weight: 600;
  color: ${theme.colors.sub};
`;

export const ContactModalContext = styled.p`
  text-align: center;
  font-size: 15px;
  font-style: normal;
  font-weight: 500;
  line-height: 28.8px;
  color: #8b8b8b;
`;

export const ContactModalContentWrap = styled.div`
  display: inline-flex;
  flex-direction: column;
  justify-content: flex-end;
  gap: 24px;

  @media only screen and (max-width: 800px) {
    gap: 0px;
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
  border-radius: 8px;
  color: ${theme.colors.sub};
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
    border-radius: 6px;
    background: ${theme.colors.primary};
    font-size: 12px;
  }
`;
