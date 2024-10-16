import HomeDesc from "./HomeDesc";
import {
  HomeDescImg,
  HomeDescImgBox,
  HomeNoteImgWrap,
} from "../../styles/home/homeLevTwoStyle";

const HomeLevTwo = () => {
  return (
    <HomeDesc
      headlineContent="Fintech Enterprise for Resolution of Information Asymmetry"
      lgDescContent="고도화된 증권정보를 바탕으로 시장의 정보 비대칭성 해소 및 혁신을 위한 핀테크 엔터프라이즈"
      descContent="투자자 니즈에 맞춰 세부적으로 계량화 된 독창적인 컨텐츠를 제공합니다."
      renderContent={() => (
        <HomeDescImgBox>
          <HomeDescImg src="/assets/dolfin.svg" alt="dol" />
        </HomeDescImgBox>
      )}
      renderImgContent={() => (
        <HomeNoteImgWrap>
          <img src="/assets/mockup1.png" alt="mockup" />
        </HomeNoteImgWrap>
      )}
    />
  );
};

export default HomeLevTwo;
