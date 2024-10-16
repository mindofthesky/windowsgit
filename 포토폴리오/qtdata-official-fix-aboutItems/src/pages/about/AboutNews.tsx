import Head from "../../components/commons/Headline/Head";
import NewsSection from "../../components/news/NewsSection";
import AboutNewsSlide from "./AboutNewsSlide";
import {
  AboutNewsBox,
  AboutNewsWrap,
  HeadlineBox,
} from "../../styles/about/aboutOurNewsStyle";

const AboutNews = () => {
  return (
    <AboutNewsWrap>
      <HeadlineBox>
        <Head content="Our News" color="sub" />
      </HeadlineBox>
      <AboutNewsBox>
        <NewsSection />
      </AboutNewsBox>
      <AboutNewsSlide />
    </AboutNewsWrap>
  );
};

export default AboutNews;
