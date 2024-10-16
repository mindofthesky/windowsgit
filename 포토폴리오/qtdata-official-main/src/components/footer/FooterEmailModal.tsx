import {
  ModalHeader,
  ModalLayout,
  ModalTitle,
  ModalTitleBox,
  ModalContentBox,
  ModalBtnBox,
  MailModalBtn,
} from "../../styles/modal/modalStyle";

interface EmailModalProps {
  closeModal: () => void;
}

const FooterEmailModal: React.FC<EmailModalProps> = ({ closeModal }) => {
  return (
    <ModalLayout>
      <ModalHeader>
        <ModalTitleBox>
          <ModalTitle>이메일무단수집거부</ModalTitle>
        </ModalTitleBox>
      </ModalHeader>
      <ModalContentBox>
        <p>
          본 홈페이지에 게시된 이메일 주소가 전자우편 수집 프로그램이나 그 밖의
          기술적 장치를 이용하여 무단으로 수집되는 것을 거부하며, 이를 위반 시
          '정보통신망이용촉진및정보보호등에관한법률'에 의해 처벌 받을 수
          있습니다.
        </p>
        <br />
        <p>정보통신망법 제50조의2 (전자우편주소의 무단 수집행위 등 금지)</p>
        <p>
          ① 누구든지 인터넷 홈페이지 운영자 또는 관리자의 사전 동의 없이 인터넷
          홈페이지에서 자동으로 전자우편주소를 수집하는 프로그램이나 그 밖의
          기술적 장치를 이용하여 전자우편주소를 수집하여서는 아니 된다.
        </p>
        <p>
          ② 누구든지 제1항을 위반하여 수집된 전자우편주소를 판매·유통하여서는
          아니 된다.
        </p>
        <p>
          ③ 누구든지 제1항과 제2항에 따라 수집·판매 및 유통이 금지된
          전자우편주소임을 알면서 이를 정보 전송에 이용하여서는 아니 된다.
        </p>
      </ModalContentBox>
      <ModalBtnBox>
        <MailModalBtn onClick={closeModal}>확인</MailModalBtn>
      </ModalBtnBox>
    </ModalLayout>
  );
};

export default FooterEmailModal;
