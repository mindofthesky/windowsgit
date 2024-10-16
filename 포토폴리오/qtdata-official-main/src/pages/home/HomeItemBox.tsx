import React from "react";
import Desc from "../../components/commons/Desc/Desc";
import ItemTitle from "../../components/commons/Title/ItemTitle";
import { IHomeItemBoxProps } from "../../types/homeTypsx";
import { theme } from "../../themes/themes";
import {
  HomeItemContainer,
  HomeItemDecsBox,
  HomeItemImg,
  HomeItemImgBox,
  HomeItemTitleBox,
} from "../../styles/home/homeItemBoxStyle";

const HomeItemBox: React.FC<IHomeItemBoxProps> = ({
  itemImgSrc,
  itemImgAlt,
  itemTitle,
  descContent,
  titleStyles,
  imageSize = "100%",
}) => {
  return (
    <HomeItemContainer>
      <HomeItemImgBox>
        <HomeItemImg src={itemImgSrc} alt={itemImgAlt} imageSize={imageSize} />
      </HomeItemImgBox>
      <HomeItemTitleBox>
        <ItemTitle content={itemTitle} styles={titleStyles} />
      </HomeItemTitleBox>
      <HomeItemDecsBox>
        <Desc
          content={descContent}
          color={theme.colors.sub}
          fontWeight="400"
        ></Desc>
      </HomeItemDecsBox>
    </HomeItemContainer>
  );
};

export default HomeItemBox;
