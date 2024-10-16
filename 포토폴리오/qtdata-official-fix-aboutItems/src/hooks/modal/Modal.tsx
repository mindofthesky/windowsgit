import React, { useEffect } from "react";
import { ModalProps } from "../../types/modalTypes";
import { ModalContent, ModalLayout } from "./modalStyle";

const Modal: React.FC<ModalProps> = ({ isOpen, content, onClose }) => {
  useEffect(() => {
    const handleEscapeKey = (event: KeyboardEvent) => {
      if (event.key === "Escape") {
        onClose();
      }
    };

    document.addEventListener("keydown", handleEscapeKey);

    return () => {
      document.removeEventListener("keydown", handleEscapeKey);
    };
  }, [onClose]);

  if (!isOpen) return null;

  return (
    <ModalLayout onClick={onClose}>
      <ModalContent onClick={(e) => e.stopPropagation()}>
        {content}
      </ModalContent>
    </ModalLayout>
  );
};

export default Modal;
