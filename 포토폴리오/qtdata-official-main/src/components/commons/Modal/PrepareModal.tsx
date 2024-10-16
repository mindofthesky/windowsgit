import React from "react";
import {
  ModalLayout,
  ModalTitle,
  ModalBtnWrap,
  ModalContentWrap,
  ModalBtnBox,
  ModalBtn,
  ModalContext,
} from "../../../styles/modal/modalStyle";

interface PrepareModalProps {
  modalTitle: string;
  closeModal: () => void;
}

const PrepareModal: React.FC<PrepareModalProps> = ({
  modalTitle,
  closeModal,
}) => {
  return (
    <ModalLayout>
      <ModalBtnWrap></ModalBtnWrap>
      <ModalContentWrap>
        <ModalTitle>준비 중이에요.</ModalTitle>
        <ModalContext>
          조금만 기다려주세요 {modalTitle}는 준비중이에요.
        </ModalContext>
      </ModalContentWrap>
      <ModalBtnBox>
        <ModalBtn onClick={closeModal}>확인</ModalBtn>
      </ModalBtnBox>
    </ModalLayout>
  );
};

export default PrepareModal;
