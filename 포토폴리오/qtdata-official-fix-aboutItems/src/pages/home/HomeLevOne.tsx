import {
  HomeImageWrap,
  HomeImg,
  HomeLevOneContainer,
  MHomeImg,
  Slogan,
  SloganBox,
  SloganSub,
} from "../../styles/home/homeLevOneStyle";

const HomeLevOne = () => {
  return (
    <HomeLevOneContainer>
      <HomeImageWrap>
        <HomeImg src="/assets/mainBg.jpg" alt="main" />
        <MHomeImg src="/assets/mainBg.jpg" alt="main" />
        <SloganBox>
          <Slogan>Global leader in investment education</Slogan>
          <SloganSub>QUANTUM DATA</SloganSub>
        </SloganBox>
      </HomeImageWrap>
    </HomeLevOneContainer>
  );
};

export default HomeLevOne;
