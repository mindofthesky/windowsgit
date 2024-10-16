import Head from "../../components/commons/Headline/Head";
import NewsSection from "../../components/news/NewsSection";
import {
  ContentContainer,
  ContentNewsWrap,
  ContentWrap,
} from "../../styles/contents/contents";
import { HeadlineBox } from "../../styles/about/aboutOurNewsStyle";

const Contents = () => {
  return (
    <ContentWrap>
      <div>
        <ContentContainer>
          <HeadlineBox>
            <Head content="Our News" color="sub" />
          </HeadlineBox>
          <ContentNewsWrap>
            <NewsSection />
          </ContentNewsWrap>
        </ContentContainer>
      </div>
    </ContentWrap>
  );
};

export default Contents;
