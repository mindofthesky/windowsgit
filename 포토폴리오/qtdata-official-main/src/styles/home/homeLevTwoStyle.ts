import styled from "styled-components";

export const HomeDescContainer = styled.div`
  position: relative;
  display: flex;
  align-items: center;
  flex-direction: column;
  width: 100%;
  height: 880px;

  @media only screen and (max-width: 800px) {
    max-height: 540px;
  }
`;

export const HomeDescTitleWrap = styled.div`
  display: flex;
  z-index: 1;
  align-items: center;
  flex-direction: column;
  row-gap: 50px;
  width: 80%;
  margin-bottom: 40px;

  @media only screen and (max-width: 800px) {
    row-gap: 60px;
    width: 80%;
    margin-bottom: 0px;
  }
`;

export const HomeLgDescWrap = styled.div`
  z-index: 1;
  margin-bottom: 20px;
  text-align: center;

  @media only screen and (max-width: 800px) {
    width: 90%;
  }
`;

export const HomeDescWrap = styled.div`
  z-index: 1;
  width: 40%;
  text-align: center;

  @media only screen and (max-width: 800px) {
    width: 80%;
  }
`;

export const HomeNoteImgWrap = styled.div`
  position: absolute;
  top: 100%;
  --translate-y: -50%;
  --translate-x: -50%;
  transform: translate(0, var(--translate-y)) rotate(0) skew(0) scaleX(1)
    scaleY(1);

  @media only screen and (max-width: 800px) {
    display: block;
    margin-top: 100px;
    margin-bottom: 20px;
  }
`;

export const HomeNoteImg = styled.img`
  width: 800px;
  height: 600px;
  max-width: none;
  background-color: transparent;
`;

export const HeadlineContainer = styled.div`
  text-align: center;
  width: 100%;
  max-width: 1040px;

  @media only screen and (max-width: 800px) {
    max-width: 298px;
    margin-bottom: 40px;
  }
`;

export const HomeDescImgBox = styled.div`
  display: flex;
  justify-content: center;
`;

export const HomeDescImg = styled.img`
  width: 52px;
  height: 52px;
`;
