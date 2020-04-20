using System;
using System.Collections.Generic;

public class Trello
{
    public int board { get; set; }
    public int card { get; set; }
}

public class AttachmentsByType
{
    public Trello trello { get; set; }
}

public class Badges
{
    public AttachmentsByType attachmentsByType { get; set; }
    public bool location { get; set; }
    public int votes { get; set; }
    public bool viewingMemberVoted { get; set; }
    public bool subscribed { get; set; }
    public string fogbugz { get; set; }
    public int checkItems { get; set; }
    public int checkItemsChecked { get; set; }
    public int comments { get; set; }
    public int attachments { get; set; }
    public bool description { get; set; }
    public DateTime? due { get; set; }
    public bool dueComplete { get; set; }
}

public class Cover
{
    public object idAttachment { get; set; }
    public object color { get; set; }
    public object idUploadedBackground { get; set; }
    public string size { get; set; }
    public string brightness { get; set; }
}

public class Card
{
    public string id { get; set; }
    public object checkItemStates { get; set; }
    public bool closed { get; set; }
    public DateTime dateLastActivity { get; set; }
    public string desc { get; set; }
    public object descData { get; set; }
    public int? dueReminder { get; set; }
    public string idBoard { get; set; }
    public string idList { get; set; }
    public List<object> idMembersVoted { get; set; }
    public int idShort { get; set; }
    public object idAttachmentCover { get; set; }
    public List<object> idLabels { get; set; }
    public bool manualCoverAttachment { get; set; }
    public string name { get; set; }
    public double pos { get; set; }
    public string shortLink { get; set; }
    public bool isTemplate { get; set; }
    public Badges badges { get; set; }
    public bool dueComplete { get; set; }
    public DateTime? due { get; set; }
    public List<object> idChecklists { get; set; }
    public List<object> idMembers { get; set; }
    public List<Label> labels { get; set; }
    public string shortUrl { get; set; }
    public bool subscribed { get; set; }
    public string url { get; set; }
    public Cover cover { get; set; }
}

public class Member
{
    public string id { get; set; }
    public string fullName { get; set; }
    public string username { get; set; }
}

public class List
{
    public string id { get; set; }
    public string name { get; set; }
    public bool closed { get; set; }
    public string idBoard { get; set; }
    public double pos { get; set; }
    public bool subscribed { get; set; }
    public object softLimit { get; set; }
}

public class Label
{
    public string id { get; set; }
    public string idBoard { get; set; }
    public string name { get; set; }
    public string color { get; set; }
}

public class Preview
{
    public string id { get; set; }
    public string _id { get; set; }
    public bool scaled { get; set; }
    public string url { get; set; }
    public int bytes { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}

public class Attachement
{
    public string id { get; set; }
    public int bytes { get; set; }
    public DateTime date { get; set; }
    public string edgeColor { get; set; }
    public string idMember { get; set; }
    public bool isUpload { get; set; }
    public object mimeType { get; set; }
    public string name { get; set; }
    public List<Preview> previews { get; set; }
    public string url { get; set; }
    public int pos { get; set; }
}