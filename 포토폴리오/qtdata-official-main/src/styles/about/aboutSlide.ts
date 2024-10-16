import styled from 'styled-components';
import { Swiper as Swp } from 'swiper/react';
import { theme } from '../../themes/themes';

export const AboutSlide = styled(Swp)`
  background-color: #000;
  width: 100vw;
  height: 280px;

  .swiper-slide {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 380px;
    text-align: center;
    font-size: 18px;
    background-color: ${theme.colors.white};
  }

  .swiper-slide img {
    display: block;
    object-fit: cover;
    width: 500px;
    height: 100%;
  }

  .swiper-button-prev,
  .swiper-button-next {
    padding: 15px 5px;
    border-radius: 0px;
    color: blue !important;
    background-color: ${theme.colors.white};
    width: 48px;
    height: 48px;
    top: 93%;
  }

  .swiper-button-next {
    right: 0;
  }

  .swiper-button-prev {
    left: 244px;
  }

  .swiper-button-prev:after,
  .swiper-button-next:after {
    font-size: 0.65rem !important;
    font-weight: bolder !important;
  }

  .swiper-pagination {
    position: absolute;
    display: flex;
    column-gap: 8px;
    top: 28px;
    right: 10%;
    left: 85%;
    color: ${theme.colors.white};
    font-weight: 400;
    font-size: 12px;
    line-height: 14px;
    background-color: transparent;
  }

  .swiper-pagination:after {
    color: #fff;
    background-color: transparent;
  }
`;

export const SlideDescBox = styled.div`
  position: absolute;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  gap: 4px;
  width: 216px;
  transform: translate(15%, -180%);
`;

export const SlideName = styled.div`
  display: flex;
  gap: 4px;
  font-size: 24px;
  font-weight: 700;
  line-height: 20px;
  color: ${theme.colors.black};
`;

export const SlideSlogan = styled.div`
  display: flex;
  justify-content: flex-start;
  height: 59px;
  text-align: left;
  white-space: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 30px;
  color: ${theme.colors.disabled};
`;
