import React, { useState, ChangeEvent } from "react";
import axios from "axios";
import Modal from "../../hooks/modal/Modal";
import useModal from "../../hooks/modal/useModal";
import ContactAgree from "./ContactAgree";
import { FormData } from "../../types/contactTypes";
import { collaboItems } from "../../datas/contactItems";
import {
  AgreeCheckBox,
  AgreeLabel,
  AgreeLabelBox,
  AgreePopupTag,
  ContactAgreeWrap,
  ContactBox,
  ContactCheckBox,
  ContactErrMsg,
  ContactInput,
  ContactInquiryBox,
  ContactItems,
  ContactLabel,
  ContactMapBox,
  ContactTextArea,
  ContentTitle,
  ErrorMsg,
  SubmitBtn,
} from "../../styles/contact/contactLevThrStyle";

const ContactLevthr: React.FC = () => {
  const [formData, setFormData] = useState<FormData>({});
  const [agreeChecked, setAgreeChecked] = useState(false);
  const [, setLoading] = useState(false);
  const [errors, setErrors] = useState<Record<string, string>>({});
  const { isModalOpen, modalContent, openModal, closeModal } = useModal();

  const handleChange = (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    fieldName: string
  ) => {
    setFormData({
      ...formData,
      [fieldName]: event.target.value,
    });

    setErrors({
      ...errors,
      [fieldName]: "",
    });
  };

  const handleCheckboxChange = () => {
    setAgreeChecked(!agreeChecked);

    const newErrors = {
      ...errors,
      agreeChecked: "",
    };

    setErrors(newErrors);
  };

  const validateEmail = (email: string): boolean => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  };

  const validateContact = (contact: string): boolean => {
    const contactRegex = /^[0-9]*$/;
    return contactRegex.test(contact);
  };

  const handleSubmit = async (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();

    const newErrors: Record<string, string> = {};

    for (const item of collaboItems) {
      const fieldName = item.dataname;
      if (!formData[fieldName]) {
        newErrors[fieldName] = `${item.name}(을)를 입력해주세요.`;
      }
    }

    if (formData.email && !validateEmail(formData.email)) {
      newErrors.email = "올바른 이메일 형식이 아닙니다.";
    }

    if (formData.contact && !validateContact(formData.contact)) {
      newErrors.contact = "올바른 휴대번호 형식이 아닙니다.";
    }

    if (!agreeChecked) {
      newErrors.agreeChecked = "";
    }

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    try {
      setLoading(true);

      console.log("formData:", formData);

      const axiosInstance = axios.create({
        baseURL: "https://sendemail.qtdata.co.kr/api",
      });
      const response = await axiosInstance.post("/send-mail", formData);

      if (response.status === 200) {
        alert(
          `\n\n안녕하세요. 퀀텀데이터 입니다.\n ${formData.company}께서 문의하신 내용이 접수되었습니다.\n 담당자가 상세히 확인한 후 신속히 연락드리도록 최선을 다하겠습니다.\n\n이용해주셔서 감사합니다.`
        );
      } else {
        alert("문의 전송에 실패했습니다.");
      }
    } catch (error) {
      console.error("문의 전송 중 오류 발생:", error);
    } finally {
      setLoading(false);
    }
  };

  const openAgreeModal = () => {
    const content = <ContactAgree closeModal={closeModal} />;
    openModal(content);
  };

  return (
    <ContactMapBox>
      <ContactInquiryBox>
        <ContentTitle>문의하기</ContentTitle>
        <ContactItems>
          {collaboItems.map((item, index) => (
            <ContactBox key={index}>
              <ContactLabel>{item.name}</ContactLabel>

              {item.name === "문의 내용" ? (
                <>
                  <ContactTextArea
                    onChange={(event) => handleChange(event, item.dataname)}
                    error={!!errors[item.dataname]}
                  />
                  {errors[item.dataname] && (
                    <ErrorMsg>{errors[item.dataname]}</ErrorMsg>
                  )}
                </>
              ) : (
                <>
                  <ContactInput
                    type="text"
                    onChange={(event) => handleChange(event, item.dataname)}
                    error={!!errors[item.dataname]}
                  />
                  {errors[item.dataname] && (
                    <ErrorMsg>{errors[item.dataname]}</ErrorMsg>
                  )}
                </>
              )}
            </ContactBox>
          ))}
          <ContactAgreeWrap>
            <AgreeCheckBox>
              <AgreeLabelBox>
                <ContactCheckBox
                  onChange={handleCheckboxChange}
                  error={!!errors.agreeChecked}
                  type="checkbox"
                />
                <AgreeLabel>
                  <div>
                    <AgreePopupTag onClick={(e) => openAgreeModal()}>
                      개인정보의 수집 및 이용목적
                    </AgreePopupTag>
                    에 동의합니다.
                  </div>
                </AgreeLabel>
                {errors.agreeChecked && (
                  <ContactErrMsg error={!!errors.agreeChecked}>
                    {errors.agreeChecked}
                  </ContactErrMsg>
                )}
              </AgreeLabelBox>
              <Modal
                isOpen={isModalOpen}
                content={modalContent}
                onClose={closeModal}
              />
            </AgreeCheckBox>
          </ContactAgreeWrap>

          <SubmitBtn onClick={handleSubmit}>문의하기</SubmitBtn>
        </ContactItems>
      </ContactInquiryBox>
    </ContactMapBox>
  );
};

export default ContactLevthr;
