import styled from "styled-components";
import { theme } from "../../themes/themes";

/** emailmodal 내부컨텐츠 */

export const ModalLayout = styled.div`
  z-index: 9999;
  display: inline-flex;
  flex-direction: column;
  gap: 20px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    gap: 0px;
  }
`;

export const ModalHeader = styled.div`
  display: flex;
  justify-content: center;

  @media only screen and (max-width: 800px) {
    padding: 0 24px;
  }
`;

export const ModalTitleBox = styled.div`
  display: flex;
  justify-content: center;
  width: 100%;
  padding-top: 24px;

  @media only screen and (max-width: 800px) {
    padding: 20px 24px;
  }
`;

export const ModalTitle = styled.p`
  justify-content: center;
  font-size: 24px;
  font-weight: 600;
  color: ${theme.colors.sub};
  text-align: center;

  @media only screen and (max-width: 800px) {
    font-size: 16px;
    font-style: normal;
    font-weight: 600;
    line-height: 26.6px;
  }
`;

export const ModalContext = styled.p`
  text-align: center;
  font-size: 15px;
  font-style: normal;
  font-weight: 500;
  line-height: 28px;
  white-space: normal;
  color: #8b8b8b;

  @media only screen and (max-width: 800px) {
    margin-bottom: 24px;
    font-size: 12px;
    line-height: 20px;
  }
`;

export const ModalContentBox = styled.div`
  overflow-y: auto;
  padding: 0px 12px;
  margin: 10px 0;
  max-height: 164px;
  font-weight: 100;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-size: 12px;
    line-height: 20px;
    font-weight: 100;
  }
`;

export const ModalBtnWrap = styled.div`
  @media only screen and (max-width: 800px) {
    display: flex;
    justify-content: flex-end;
  }
`;

export const ModalCloseBtn = styled.button`
  font-size: 24px;
`;

export const ModalContentWrap = styled.div`
  display: flex;
  justify-content: center;
  flex-direction: column;
  gap: 20px;
  padding: 20px;
  width: 100%;
  text-align: center;

  @media only screen and (max-width: 800px) {
    padding: 0px;
  }
`;

export const ModalBtnBox = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  padding-bottom: 36px;

  @media only screen and (max-width: 800px) {
    padding-bottom: 20px;
  }
`;

export const ModalBtn = styled.button`
  height: 44px;
  padding: 12px 24px;
  font-size: 16px;
  font-weight: 500;
  color: ${theme.colors.sub};
  border-radius: 6px;
  background: ${theme.colors.enable};
  transition: all 0.2s ease-out;

  &:hover {
    background: ${theme.colors.primary};
    transition: all 0.2s ease-out;
  }

  @media only screen and (max-width: 800px) {
    height: 36px;
    padding: 6px 12px;
    font-size: 12px;
    line-height: 24px;
    background: ${theme.colors.primary};
  }
`;

export const MailModalBtn = styled(ModalBtn)`
  display: flex;
  justify-content: flex-end;
`;
