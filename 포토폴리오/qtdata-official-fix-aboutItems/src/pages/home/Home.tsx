import HomeLevOne from "./HomeLevOne";
import HomeLevTwo from "./HomeLevTwo";
import HomeLevThr from "./HomeLevThr";
import HomeLevFour from "./HomeLevFour";
import HomeLevFif from "./HomeLevFif";
import { HomeLayout, HomeWrap, HiddenDiv } from "../../styles/home/home";

const Home = () => {
  return (
    <HomeLayout>
      <HomeWrap>
        <HomeLevOne />
        <HomeLevTwo />
        <HiddenDiv />
        <HomeLevThr />
        <HiddenDiv />
        <HomeLevFour />
        <HiddenDiv />
        <HomeLevFif />
        <HiddenDiv />
      </HomeWrap>
    </HomeLayout>
  );
};

export default Home;
