import React from "react";
import {
  ContentsBox,
  MNewsDate,
  NewArrowIcon,
  NewsArrowBox,
  NewsArrowEllipse,
  NewsContents,
  NewsDate,
  NewsImg,
  NewsImgBox,
  NewsMediaBox,
  NewsMediaName,
  NewsSectionWrap,
  NewsTag,
  NewsTitle,
  TitleBox,
} from "../../styles/news/news";

import { newsItems } from "../../datas/newsItems";
import Loader from "../../utils/Loader";

const NewsSection = () => {
  return (
    <>
      <NewsSectionWrap>
        {newsItems.map((item, index) => (
          <NewsTag target="_blank" key={index} href={item.newsHref}>
            {item.newsSrc ? (
              <>
                <NewsImgBox>
                  <NewsImg src={item.newsSrc} alt={item.newsAlt} />
                </NewsImgBox>
                <NewsMediaBox>
                  <NewsMediaName>{item.newsName}</NewsMediaName>
                  <NewsDate>{item.newsDate}</NewsDate>
                </NewsMediaBox>

                <TitleBox>
                  <NewsTitle>{item.newsTitle}</NewsTitle>
                </TitleBox>
                <ContentsBox>
                  <NewsContents>{item.newsContent}</NewsContents>
                  <MNewsDate>{item.newsDate}</MNewsDate>
                </ContentsBox>

                <NewsArrowBox>
                  <NewsArrowEllipse
                    className="arrow-icon"
                    src="/assets/newsEllipseRD.svg"
                    alt="Ellipse"
                  />
                  <NewArrowIcon
                    src="/assets/navigateNext.svg"
                    className="arrow-icon"
                  />
                </NewsArrowBox>
              </>
            ) : (
              <Loader loading={!item.newsSrc} />
            )}
          </NewsTag>
        ))}
      </NewsSectionWrap>
    </>
  );
};

export default NewsSection;
