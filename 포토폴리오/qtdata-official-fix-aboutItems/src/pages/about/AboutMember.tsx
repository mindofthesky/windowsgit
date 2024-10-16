import React from "react";
import { TMember, TMemberData } from "../../types/aboutTypes";
import AboutRowOne from "./AboutRowOne";
import AboutRowTwo from "./AboutRowTwo";
import {
  AboutLeaderMembers,
  AboutListLayout,
  ListUl,
} from "../../styles/about/aboutMemberStyle";

const AboutMember = ({
  infoMembers,
  selectCard,
}: {
  infoMembers: TMemberData[];
  selectCard: (e: React.MouseEvent, selectedMember: TMember) => void;
}) => {
  return (
    <AboutLeaderMembers>
      <nav>
        <ListUl>
          <AboutListLayout>
            <AboutRowOne />
            <AboutRowTwo selectCard={selectCard} infoMembers={infoMembers} />
          </AboutListLayout>
        </ListUl>
      </nav>
    </AboutLeaderMembers>
  );
};

export default AboutMember;
