import styled from "styled-components";

export const ModalLayout = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 10;

  @media only screen and (max-width: 800px) {
    box-shadow: 8px 16px 30px 0px rgba(29, 29, 29, 0.15);
  }
`;

export const ModalContent = styled.div`
  background: #fff;
  padding: 0 20px;
  margin-top: 100px;
  width: auto;
  height: auto;
  max-width: 520px;
  max-height: 500px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  z-index: 10;

  @media only screen and (max-width: 800px) {
    margin: 0 24px;
  }
`;
