import {
  FourTitle,
  FourTitleImg,
  LevFourDesc,
  LevFourTitle,
  LevFourTitleBox,
  NeosLevFourWrap,
} from "../../styles/joosikbox/neos";

const NeosLevFour = () => {
  return (
    <NeosLevFourWrap>
      <LevFourTitleBox>
        <LevFourTitle>
          <FourTitle>What makes </FourTitle>
          <FourTitleImg src="/assets/neos.svg" alt="neos" />
          <FourTitle> different?</FourTitle>
        </LevFourTitle>
      </LevFourTitleBox>
      <div style={{ width: "64%" }}>
        <LevFourDesc>
          NEOS는 웨이브릿지의 가상자산 퀀트 역량과 미국 내 옵션 인컴(Option
          Income) ETF 전략의 전문가로 구성되어 있으며, 수십 년간 전통적인 자산
          관리 및 인덱싱 노하우에 디지털 방식의 전문 지식을 결합한 투자금융
          솔루션을 제공합니다. 그 중심에 이태용 파트너와 핵심 멤버인
          게럿(Garrett Paolella)과 트로이(Troy Cates)는 그동안의 금융 시장에서
          입증된 실적을 바탕으로 옵션 기반 인컴 ETF전략과 퀀트 역량을 결합한
          상품들을 출시하며 디지털 자산 시장에 있어서도 반복된 성공의 청사진을
          제시합니다.
        </LevFourDesc>
      </div>
    </NeosLevFourWrap>
  );
};

export default NeosLevFour;
