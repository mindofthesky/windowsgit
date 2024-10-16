import React, { useState } from "react";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";

import "./styles.css";

import { Pagination, Navigation, Mousewheel, Keyboard } from "swiper/modules";
import { newsItems } from "../../datas/newsItems";
import { MAboutNewsLayout } from "../../styles/news/news";
import {
  ContentsBox,
  DateBox,
  MNewsSectionWrap,
  MediaNameBox,
  NewsContents,
  NewsDate,
  NewsMediaName,
  NewsTitle,
  TitleBox,
} from "../../styles/news/news";

const AboutNewsSlide = () => {
  const [activeIndex, setActiveIndex] = useState(0);

  const handleSlideChange = (swiper: any) => {
    setActiveIndex(swiper.activeIndex);
    // 여기서 원하는 작업 수행
  };
  return (
    <MAboutNewsLayout>
      <Swiper
        onSlideChange={handleSlideChange}
        pagination={{
          type: "fraction",
        }}
        cssMode={true}
        navigation={true}
        mousewheel={true}
        keyboard={true}
        modules={[Pagination, Navigation, Mousewheel, Keyboard]}
        className="mySwiper"
      >
        {newsItems.map((news, index) => (
          <SwiperSlide key={news.id}>
            <img src={news.newsSrc} alt={news.newsAlt} />
          </SwiperSlide>
        ))}
      </Swiper>

      <MNewsSectionWrap>
        <MediaNameBox>
          <NewsMediaName>{newsItems[activeIndex].newsName}</NewsMediaName>
        </MediaNameBox>
        <TitleBox>
          <NewsTitle>{newsItems[activeIndex].newsTitle}</NewsTitle>
        </TitleBox>
        <ContentsBox>
          <NewsContents>{newsItems[activeIndex].newsContent}</NewsContents>
        </ContentsBox>
        <DateBox>
          <NewsDate>{newsItems[activeIndex].newsDate}</NewsDate>
        </DateBox>
      </MNewsSectionWrap>
    </MAboutNewsLayout>
  );
};

export default AboutNewsSlide;
