import React from "react";
import {
  FifProName,
  FifProfile,
  LevFifProBox,
} from "../../styles/joosikbox/neos";

interface IProfileCardProps {
  imageSrc: string;
  name: string;
  profile: string;
}
const NeosProfileCard: React.FC<IProfileCardProps> = ({
  imageSrc,
  name,
  profile,
}) => {
  return (
    <LevFifProBox>
      <div style={{ marginBottom: "24px" }}>
        <img
          style={{ width: "240px", height: "auto" }}
          src={imageSrc}
          alt={name}
        />
      </div>
      <div style={{ marginBottom: "20px" }}>
        <FifProName>{name}</FifProName>
      </div>
      <div>
        <FifProfile>{profile}</FifProfile>
      </div>
    </LevFifProBox>
  );
};

export default NeosProfileCard;
