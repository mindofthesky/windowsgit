import HomeDesc from './HomeDesc';
import useModal from '../../hooks/modal/useModal';
import Modal from '../../hooks/modal/Modal';

import {
  FourArrowImg,
  HomeFourArrowTag,
  HomeFourContainer,
  HomeFourNoteImg,
  HomeFourWrap,
} from '../../styles/home/homeLevFourStyle';

const HomeLevFour = () => {
  const { isModalOpen, modalContent, closeModal } = useModal();

  // const prepareAlert = (
  //   e: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
  //   modalTitle?: string
  // ) => {
  //   e.preventDefault();
  //   const content = (
  //     <PrepareModal modalTitle={modalTitle || ""} closeModal={closeModal} />
  //   );

  //   openModal(content);
  // };

  return (
    <HomeFourWrap>
      <HomeFourContainer>
        <div>
          <HomeFourNoteImg src='/assets/mockup2.png' alt='mockup' />
        </div>
        <HomeDesc
          headlineContent='Platform of Platform for Investor'
          lgDescContent='고도화된 증권정보를 All-In-One 서비스하는 플랫폼의 플랫폼'
          descContent='
'
          renderImgContent={() => (
            <>
              <span>
                고도화된 증권정보를 기반으로 투자자의 증권시장 진입장벽을
                낮추고, 증권정보의 다양한 해석을 가능하게 함으로써
              </span>
              <span>
                독창적인 포트폴리오 전략 및 셀프 펀드 개발이 보다 용이해 집니다.
              </span>
              <span>
                방송, 교육, 증권 프로그램, 레포트 마켓 등 다양한 증권 플랫폼을
                통하여 증권 교육의 새로운 패러다임을 제시합니다.
              </span>
              <span>
                최적화된 애그리게이터 서비스를 제공하여 밸류업을 가능하게
                합니다.
              </span>
              <HomeFourArrowTag href='/joosikbox'>
                주식박스로 이동하기
                <FourArrowImg src='/assets/navigateNext.svg' alt='arrow' />
              </HomeFourArrowTag>
            </>
          )}
        />
        <Modal
          isOpen={isModalOpen}
          content={modalContent}
          onClose={closeModal}
        />
      </HomeFourContainer>
    </HomeFourWrap>
  );
};

export default HomeLevFour;
