import Modal from "../../hooks/modal/Modal";
import useModal from "../../hooks/modal/useModal";
import {
  ArrowDownIcon,
  FooterIconBox,
  FooterRightWrap,
  FooterSectionRight,
  FooterSelect,
  Icon,
  IconContainer,
  IconRocket,
} from "../../styles/footer/footer";
import PrepareModal from "../commons/Modal/PrepareModal";

const FooterRight = () => {
  const { isModalOpen, modalContent, openModal, closeModal } = useModal();

  const prepareAlert = (
    e?: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
    modalTitle?: string
  ) => {
    if (e) {
      e.preventDefault();
    }

    const content = (
      <PrepareModal modalTitle={modalTitle || ""} closeModal={closeModal} />
    );

    openModal(content);
  };

  return (
    <>
      <FooterRightWrap>
        <FooterSectionRight>
          <FooterIconBox>
            <IconContainer
              target="_blank"
              rel="noreferrer"
              href="https://www.facebook.com/profile.php?id=61555385858000"
            >
              {/* <IconEllipse src="/assets/Ellipse.png" alt="linkedin" /> */}
              <Icon src="/assets/facebook.svg" alt="facebook" />
            </IconContainer>
            <a
              target="_blank"
              rel="noreferrer"
              href="https://www.rocketpunch.com/companies/quantumdata"
            >
              <IconRocket src="/assets/rocket.svg" alt="rocketpunch" />
            </a>
          </FooterIconBox>
        </FooterSectionRight>
        {/* <span onClick={() => prepareAlert(undefined, "Family Site")}>
          <FooterSelect
            style={{ display: "flex", justifyContent: "space-between" }}
          >
            <option>Family Site</option>
            <ArrowDownIcon src="/assets/arrow-down.svg" alt="arrow-down" />
          </FooterSelect>
        </span> */}

        {/* 임시 셀렉박스 */}
        <FooterSelect onClick={() => prepareAlert(undefined, "Family Site")}>
          <p>Family Site</p>
          <ArrowDownIcon src="/assets/arrow-down.svg" alt="arrow-down" />
        </FooterSelect>
        <Modal
          isOpen={isModalOpen}
          content={modalContent}
          onClose={closeModal}
        />
      </FooterRightWrap>
    </>
  );
};

export default FooterRight;
