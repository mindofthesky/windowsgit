import Modal from '../../hooks/modal/Modal';
import useModal from '../../hooks/modal/useModal';
import {
  FooterLeftWrap,
  FooterSection,
  FooterLogo,
  FooterDesc,
  Partition,
  FooterInfo,
  FooterEmailPopupTag,
  FooterDescBox,
  Partitions,
  MFooterContact,
  InfoBox,
  FooterRecruitTag,
} from '../../styles/footer/footer';
import { Link } from 'react-router-dom';
import FooterEmailModal from './FooterEmailModal';
import ContactAgree from '../../pages/contact/ContactAgree';

const FooterLeft = () => {
  const { isModalOpen, modalContent, openModal, closeModal } = useModal();

  const openEmailModal = () => {
    const content = <FooterEmailModal closeModal={closeModal} />;
    openModal(content);
  };

  const openAgreeModal = () => {
    const content = <ContactAgree closeModal={closeModal} />;
    openModal(content);
  };

  return (
    <>
      <FooterLeftWrap>
        <FooterSection>
          <FooterLogo src='/assets/footerLogo.svg' alt='logo' />
        </FooterSection>
        <FooterSection>
          <FooterDesc>
            <FooterDescBox>
              <InfoBox>
                <button onClick={(e) => openAgreeModal()}>
                  개인정보 처리 방침
                </button>
              </InfoBox>

              <Partition></Partition>
              <div>
                <FooterRecruitTag
                  style={{
                    alignItems: 'center',
                    display: 'flex',
                  }}
                  href='/recruit'
                >
                  채용정보
                </FooterRecruitTag>
              </div>
            </FooterDescBox>
            <Partitions></Partitions>
            <FooterDescBox>
              <Link to='/contact'>contact@qtdata.co.kr</Link>
              <Partition></Partition>
              <div>
                <FooterEmailPopupTag onClick={openEmailModal}>
                  이메일무단수집거부
                </FooterEmailPopupTag>
              </div>
            </FooterDescBox>
          </FooterDesc>
        </FooterSection>
        <FooterSection>
          <FooterInfo>
            <p>주식회사 퀀텀데이터</p>
            <p>서울시 강남구 봉은사로 437 소암빌딩 6층</p>
            <p>사업자등록번호: 278-88-02875</p>
            <MFooterContact>
              Copyright 2024. QUANTUMDATA Inc. All rights reserved.
            </MFooterContact>
          </FooterInfo>
        </FooterSection>
        <FooterSection></FooterSection>
      </FooterLeftWrap>
      <Modal isOpen={isModalOpen} content={modalContent} onClose={closeModal} />
    </>
  );
};

export default FooterLeft;
