import React from "react";
import {
  ModalHeader,
  ModalLayout,
  ModalTitle,
  ModalTitleBox,
  ModalContentBox,
  ModalBtnBox,
  MailModalBtn,
} from "../../styles/modal/modalStyle";

interface AgreeModalProps {
  closeModal: () => void;
}

const ContactAgree: React.FC<AgreeModalProps> = ({ closeModal }) => {
  return (
    <ModalLayout>
      <ModalHeader>
        <ModalTitleBox>
          <ModalTitle>개인정보 수집 및 이용에 관한 동의사항</ModalTitle>
        </ModalTitleBox>
      </ModalHeader>
      <ModalContentBox>
        <p></p>
        <br />
        <p>
          주식회사 퀀텀데이터(이하 "회사")는 고객사(이하 "이용기관")의
          개인정보를 중요시하며 '정보통신망 이용촉진 및 정보보호 등에 관한
          법률', '개인정보보호법' 등 관련 법규에 따라 서비스(이하 "서비스")
          이용을 위한 문의사항 응대를 위해 아래와 같이 개인정보를 수집 및
          이용합니다.
        </p>
        <br />
        <p>1. 개인정보의 수집∙이용목적</p>
        <p>
          회사는 다음과 같은 목적으로 가맹점의 개인정보 항목을 수집 및 이용하고
          있습니다
        </p>

        <br />

        <p>
          - 서비스 이용에 따른 본인식별, 실명확인, 가입의사 확인, 연령제한
          서비스 이용
        </p>

        <p>
          - 고지사항 전달, 불만처리 의사소통 경로 확보, 물품배송 시 정확한
          배송지 정보 확보
        </p>

        <p>- 신규 서비스 등 최신정보 안내 및 개인맞춤서비스 제공을 위한 자료</p>

        <p>- 기타 원활한 양질의 서비스 제공 등</p>
        <br />

        <p>2. 수집하는 개인정보의 항목 : 회사명, 이름, 이메일, 전화번호</p>
        <br />
        <p>3. 개인정보의 보유 및 이용기간</p>
        <p>
          개인정보는 원칙적으로 개인정보의 수집•이용목적 달성 시 지체 없이 파기
          합니다. 단, 원활한 서비스의 상담을 위해 상담 완료 후 내용을 3개월간
          보유할 수 있으며 전자상거래에서의 소비자보호에 관한 법률 등 타법률에
          의해 보존할 필요가 있는 경우에는 일정기간 보존합니다.
        </p>
      </ModalContentBox>
      <ModalBtnBox>
        <MailModalBtn onClick={closeModal}>확인</MailModalBtn>
      </ModalBtnBox>
    </ModalLayout>
  );
};

export default ContactAgree;
