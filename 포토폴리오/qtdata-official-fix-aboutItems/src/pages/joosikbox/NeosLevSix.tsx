import { neosItems } from "../../datas/neosItems";
import {
  LevSixBox,
  LevSixBoxes,
  LevSixDesc,
  LevSixDescBox,
  LevSixTitleBox,
  NeosLevSixWrap,
  SixBoxDesc,
  SixBoxTitle,
  SixTitle,
  SixTitleImg,
} from "../../styles/joosikbox/neos";

const NeosLevSix = () => {
  return (
    <NeosLevSixWrap>
      <LevSixTitleBox>
        <SixTitleImg src="/assets/neos.svg" alt="neos" />
        <SixTitle>투자상품</SixTitle>
      </LevSixTitleBox>
      <LevSixDescBox>
        <LevSixDesc>
          NEOS는 Income 형 투자 상품을 전문으로 운용하는 회사이며, 각 기초자산을
          추종하되, 옵션 전략을 통해 월 배당을 제공할 수 있는 상품 라인업을
          구축하고 있습니다. NEOS의 3종 ETF인 SPYI, BNDI, CSHI는 미국의 CBOE와
          NYSE에 상장되어 있으며, BTCHI는 투자상품 출시를 준비 중에 있습니다.
        </LevSixDesc>
      </LevSixDescBox>
      <LevSixBoxes>
        {neosItems.map((item, index) => (
          <LevSixBox key={index}>
            <SixBoxTitle>{item.neosBoxTitle}</SixBoxTitle>
            <SixBoxDesc>{item.neosBoxDesc}</SixBoxDesc>
          </LevSixBox>
        ))}
      </LevSixBoxes>
    </NeosLevSixWrap>
  );
};

export default NeosLevSix;
