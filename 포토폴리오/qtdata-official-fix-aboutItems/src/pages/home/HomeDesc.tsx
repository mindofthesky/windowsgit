import React from "react";
import { useTheme } from "styled-components";
import Head from "../../components/commons/Headline/Head";
import LgDesc from "../../components/commons/Desc/LgDesc";
import Desc from "../../components/commons/Desc/Desc";
import { IHomeDescProps } from "../../types/homeTypsx";
import {
  HeadlineContainer,
  HomeDescContainer,
  HomeDescTitleWrap,
  HomeDescWrap,
  HomeLgDescWrap,
} from "../../styles/home/homeLevTwoStyle";

const HomeDesc: React.FC<IHomeDescProps> = ({
  headlineContent,
  lgDescContent,
  descContent,
  renderContent,
  renderImgContent,
}) => {
  const theme = useTheme();
  return (
    <HomeDescContainer>
      <HomeDescTitleWrap>
        {renderContent && renderContent()}
        <HeadlineContainer>
          <Head content={headlineContent} color={theme.colors.sub} />
        </HeadlineContainer>
      </HomeDescTitleWrap>
      <HomeLgDescWrap>
        <LgDesc content={lgDescContent} color={theme.colors.sub} />
      </HomeLgDescWrap>
      <HomeDescWrap>
        <Desc content={descContent} color={theme.colors.sub} />
      </HomeDescWrap>
      {renderImgContent && renderImgContent()}
    </HomeDescContainer>
  );
};

export default HomeDesc;
