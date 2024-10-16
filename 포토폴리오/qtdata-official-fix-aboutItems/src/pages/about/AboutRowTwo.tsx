import React from "react";
import { TMember, TMemberData } from "../../types/aboutTypes";
import {
  AboutInfoBox,
  AboutRows,
  AboutMemberList,
  AboutMemberThumb,
  AboutNick,
  AboutPosition,
  AboutThumbInfoWrap,
} from "../../styles/about/aboutMemberStyle";

const AboutRowTwo = ({
  infoMembers,
  selectCard,
}: {
  infoMembers: TMemberData[];
  selectCard: (e: React.MouseEvent, selectedMember: TMember) => void;
}) => {
  const renderAboutMember = (
    nick: string,
    position: string,
    $backgroundImage: string
  ) => (
    <AboutMemberList>
      <AboutMemberThumb $backgroundImage={$backgroundImage}>
        <AboutThumbInfoWrap>
          <AboutInfoBox>
            <AboutNick>{nick}</AboutNick>
            <AboutPosition>{position}</AboutPosition>
          </AboutInfoBox>
        </AboutThumbInfoWrap>
      </AboutMemberThumb>
    </AboutMemberList>
  );

  return (
    <>
      {infoMembers.map((row, rowIndex) =>
        row.row === "left" ? (
          <React.Fragment key={row.row} />
        ) : (
          <AboutRows key={row.row}>
            {row.members.map((member, memberIndex) => (
              <div
                className={`${rowIndex}/${memberIndex}`}
                onClick={(e: React.MouseEvent) => selectCard(e, member)}
                key={member.id}
              >
                {renderAboutMember(member.nick, member.position, member.img)}
              </div>
            ))}
          </AboutRows>
        )
      )}
    </>
  );
};

export default AboutRowTwo;
