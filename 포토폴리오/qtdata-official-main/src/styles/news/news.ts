import styled from "styled-components";
import { theme } from "../../themes/themes";

export const NewsSectionWrap = styled.div`
  overflow: hidden;
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 126px;
  row-gap: 60px;
  max-width: 1440px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    gap: 4px;
    row-gap: 40px;
  }
`;

export const NewsTag = styled.a`
  position: relative;
  width: 348px;
  height: 592px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    width: calc(50% - 28px);
    height: 350px;
  }
`;

export const NewsImgBox = styled.div`
  margin-bottom: 24px;
`;

export const NewsImg = styled.img`
  -o-object-fit: contain;
  object-fit: contain;
  width: 348px;
  height: 348px;
  border-radius: 6px;

  @media only screen and (max-width: 800px) {
    width: 160px;
    height: 160px;
    margin-right: auto;
    border-radius: 12px;
    margin: 0;
  }
`;

export const MediaNameBox = styled.div`
  margin-bottom: 12px;

  @media only screen and (max-width: 800px) {
    margin-top: 12px;
    margin-bottom: 0px;
  }
`;

export const NewsMediaBox = styled.div`
  display: flex;
  justify-content: space-between;
  margin-bottom: 12px;
`;

export const NewsMediaName = styled.span`
  font-weight: 700;
  font-size: 14px;
  line-height: 20px;
  color: ${theme.colors.disabled};

  @media only screen and (max-width: 800px) {
    font-weight: 700;
    font-size: 12px;
    line-height: 14px;
  }
`;

export const TitleBox = styled.div`
  margin-bottom: 8px;

  @media only screen and (max-width: 800px) {
    width: 90%;
  }
`;

export const NewsTitle = styled.span`
  font-weight: 700;
  font-size: 20px;
  line-height: 28px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    overflow: hidden;
    display: -webkit-box;
    -webkit-line-clamp: 1;
    -webkit-box-orient: vertical;
    font-weight: 700;
    font-size: 14px;
    line-height: 24px;
    text-overflow: ellipsis;
    word-break: break-word;
  }
`;

export const ContentsBox = styled.div`
  margin-bottom: 8px;

  @media only screen and (max-width: 800px) {
    width: 90%;
  }
`;

export const NewsContents = styled.div`
  overflow: hidden;
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  width: 100%;
  text-overflow: ellipsis;
  word-break: break-word;
  font-weight: 500;
  font-size: 16px;
  line-height: 24px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-weight: 400;
    font-size: 12px;
    line-height: 20px;
  }
`;

export const DateBox = styled.div`
  margin-bottom: 20px;
`;

export const NewsDate = styled.span`
  font-weight: 500;
  font-size: 14px;
  line-height: 20px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    display: none;
    font-weight: 500;
    font-size: 12px;
    line-height: 14px;
  }
`;

export const MNewsDate = styled.span`
  display: none;

  @media only screen and (max-width: 800px) {
    display: block;
    margin-top: 8px;
    font-weight: 500;
    font-size: 12px;
    line-height: 20px;
  }
`;

export const NewsArrowBox = styled.div`
  position: relative;
  margin-bottom: hidden;

  @media only screen and (max-width: 800px) {
    margin-top: -30px;
  }
`;

export const NewsArrowEllipse = styled.img`
  position: absolute;
  right: 0;
  display: flex;
  justify-content: flex-end;
  width: 36px;
  height: 36px;
  border-radius: 25%;
  fill: #ffcd1a;
  transform: translate(-10%, 20px);

  @media only screen and (max-width: 800px) {
    width: 24px;
    height: 24px;
    transform: translate(-50%, 20px);
  }
`;

export const NewArrowIcon = styled.img`
  position: absolute;
  right: 0;
  display: flex;
  justify-content: flex-end;
  width: 24px;
  height: 24px;
  transform: translate(-40%, 25px);

  @media only screen and (max-width: 800px) {
    transform: translate(-100%, 23px);
    width: 16px;
    height: 16px;
  }
`;

// 모바일 버전 뉴스 슬라이드 레이아웃
export const MAboutNewsLayout = styled.div`
  display: none;

  @media only screen and (max-width: 800px) {
    display: block;
  }
`;

export const MNewsSectionWrap = styled.div`
  overflow: hidden;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  row-gap: 15px;
  max-width: 1440px;
  width: 100%;
  padding: 8%;
`;
